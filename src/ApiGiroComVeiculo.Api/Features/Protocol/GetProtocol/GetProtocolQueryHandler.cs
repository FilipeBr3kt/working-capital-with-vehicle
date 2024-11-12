using ApiGiroComVeiculo.Api.Common.Abstractions;
using ApiGiroComVeiculo.Api.Common.Constants;
using ApiGiroComVeiculo.Api.Common.Exceptions;
using ApiGiroComVeiculo.Api.Common.Responses;
using ApiGiroComVeiculo.Api.Common.Utils;
using MediatR;

namespace ApiGiroComVeiculo.Api.Features.Protocol.GetProtocol;

public class GetProtocolQueryHandler : IRequestHandler<GetProtocolQuery, GetProtocolResponse>
{
    private readonly IGetProtocolRepository _repository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public GetProtocolQueryHandler(IGetProtocolRepository repository, IHttpContextAccessor httpContextAccessor)
    {
        _repository = repository;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<GetProtocolResponse> Handle(GetProtocolQuery request, CancellationToken cancellationToken)
    {
        var token = (_httpContextAccessor.HttpContext?.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last());
        string value = ValidateToken(token);

        var result = await _repository.GetProtocolAsync(value, cancellationToken)
            ?? throw new NotFoundException("Protocol not found.");

        List<Protocol> protocols = MapProtocolDto(result);

        return new GetProtocolResponse
        {
            CurrentProtocol = protocols.FirstOrDefault()!,
            HistoryProtocol = protocols.Skip(1).ToList()
        };
    }

    private static List<Protocol> MapProtocolDto(List<GetProtocolResponseView> result)
    {
        var situation = ProtocolSituation.GetProtocolStatuses();

        var protocols = result.Select(p =>
        {
            var situationItem = situation.FirstOrDefault(x => x.Id == p.Situation);

            return new Protocol
            {
                Id = p.Id,
                NumberProtocol = p.NrProtocol,
                DateRegister = p.DateRegister.ToString(),
                DateRegisterF = p.DateRegister.ToString("dd/MM/yyyy"),
                DocumentF = $"{p.Document[..2]}.***.***/****-{p.Document[^2..]}",
                Name = string.Join(" ", p.Name.Split(' ').Select((word, index) =>
                     index == 0 ? word : word[0] + new string('*', word.Length - 1))
                ),
                PhoneDdd = p.PhoneDdd,
                PhoneNumber = p.PhoneNumber,
                RequestedValue = p.RequestedValue,
                RequestedValueF = p.RequestedValue.ToString("C2"),
                Plate = $"{p.Plate[..3]}-**{p.Plate[^2..]}",
                Type = p.Type,
                Status = p.Status == 1 ? "Aberto" : "Fechado",
                CodeSituation = situationItem!.Id,
                Situation = situationItem.Title,
                ColorSituation = new Color
                {
                    Dark = situationItem.Color.Dark,
                    Light = situationItem.Color.Light
                },
                DescriptionSituation = situationItem.Description
            };
        }).ToList();
        return protocols;
    }

    private static string ValidateToken(string? token)
    {
        if (string.IsNullOrEmpty(token))
        {
            throw new UnauthorizedException("Authentication token not found.");
        }

        var tokenClaims = TokenService.GetTokenProperties(token);
        if (!tokenClaims.TryGetValue("cnpj", out string? value))
        {
            throw new UnauthorizedException("CNPJ not found in token.");
        }

        return value;
    }
}
