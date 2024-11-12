using ApiGiroComVeiculo.Api.Common.Abstractions;
using ApiGiroComVeiculo.Api.Common.DTOs;
using ApiGiroComVeiculo.Api.Common.Exceptions;
using ApiGiroComVeiculo.Api.Common.Utils;
using MediatR;

namespace ApiGiroComVeiculo.Api.Features.Auth.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IStoredProcedureRepository _repository;

    public LoginCommandHandler(IStoredProcedureRepository repository)
    {
        _repository = repository;
    }

    public async Task<LoginResponse> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        ValidateCommand(command);

        var user = new VerifyUserInformationDTO(command.Cnpj, command.Plate);
        await ValidateUserProtocol(user, cancellationToken);

        var token = TokenService.GenerateToken(command.Cnpj, command.Plate);

        return new LoginResponse(token);
    }

    private async Task ValidateUserProtocol(VerifyUserInformationDTO user, CancellationToken cancellationToken)
    {
        var response = await _repository.VerifyUserInformation(user, cancellationToken);

        if (!response.Result)
        {
            throw new BadHttpRequestException("Invalid credentials");
        }
    }

    private static void ValidateCommand(LoginCommand command)
    {
        var validator = new LoginValidator();
        var results = validator.Validate(command);

        if (!results.IsValid)
        {
            var errors = results.Errors
                .GroupBy(e => char.ToLowerInvariant(e.PropertyName[0]) + e.PropertyName.Substring(1))
                .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToList());

            throw new BadRequestException(errors);
        }
    }
}