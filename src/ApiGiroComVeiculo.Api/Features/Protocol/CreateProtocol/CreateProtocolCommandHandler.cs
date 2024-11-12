using ApiGiroComVeiculo.Api.Common.Abstractions;
using ApiGiroComVeiculo.Api.Common.DTOs;
using ApiGiroComVeiculo.Api.Common.Exceptions;
using ApiGiroComVeiculo.Api.Common.Responses;
using ApiGiroComVeiculo.Api.Common.Utils;
using AutoMapper;
using MediatR;

namespace ApiGiroComVeiculo.Api.Features.Protocol.CreateProtocol;

public class CreateProtocolCommandHandler : IRequestHandler<CreateProtocolCommand, InsertProtocolProcedureResponse>
{
    private readonly IStoredProcedureRepository _repository;
    private readonly IMapper _mapper;
    private const int _daysOffSet = 60;
    private readonly IConfiguration _configuration;

    public CreateProtocolCommandHandler(IStoredProcedureRepository repository, IMapper mapper, IConfiguration configuration)
    {
        _repository = repository;
        _mapper = mapper;
        _configuration = configuration;
    }

    public async Task<InsertProtocolProcedureResponse> Handle(CreateProtocolCommand command,
        CancellationToken cancellationToken)
    {
        ValidateCommand(command);

        await CheckExistingProtocolAsync(command, cancellationToken);

        var protocol = _mapper.Map<InsertProtocolDTO>(command);
        var saveProtocol = await _repository.InsertProtocolAsync(protocol, cancellationToken)
            ?? throw new InternalServerException("Unable to save the protocol.");

        await SendEmail(command, cancellationToken);

        return saveProtocol;
    }

    private async Task SendEmail(CreateProtocolCommand command, CancellationToken cancellationToken)
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(currentDirectory, "Common", "Templates", "request.html");
        var body = await File.ReadAllTextAsync(filePath, cancellationToken);

        body = body.Replace("{fullName}", command.CustomerName);
        body = body.Replace("{productName}", "Capital de giro");
        body = body.Replace("{amount}", command.RequestedAmount.ToString("C2"));
        body = body.Replace("{document}", command.CustomerCNPJ);
        body = body.Replace("{vehiclePlate}", command.VehiclePlate);
        body = body.Replace("{mainLinkButton}", _configuration.GetValue<string>("SecretsApi:WebPage"));

        EmailSender.SendEmail(command.ContactEmail, command.CustomerName, "Solicitacão de Giro com Veículo recebida", body);
    }

    private static void ValidateCommand(CreateProtocolCommand command)
    {
        var validator = new CreateProtocolValidator();
        var results = validator.Validate(command);

        if (!results.IsValid)
        {
            var errors = results.Errors
                .GroupBy(e => char.ToLowerInvariant(e.PropertyName[0]) + e.PropertyName.Substring(1))
                .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToList());

            throw new BadRequestException(errors);
        }
    }

    private async Task CheckExistingProtocolAsync(CreateProtocolCommand command, CancellationToken cancellationToken)
    {
        var userCredentials = new VerifyUserInformationDTO(command.CustomerCNPJ, command.VehiclePlate);
        var checkProtocol = await _repository.VerifyUserInformation(userCredentials, cancellationToken);
        if (checkProtocol.Result)
        {
            if (checkProtocol.BlAtendimento)
            {
                throw new BadRequestException("There is already a protocol with this plate and document.");
            }

            if (checkProtocol.UltDias <= _daysOffSet)
            {
                var countRemainingDays = _daysOffSet - checkProtocol.UltDias;
                throw new BadRequestException($"Wait {countRemainingDays} days to make a new request or provide another vehicle");
            }
        }
    }
}