namespace ApiGiroComVeiculo.Api.Features.Parameters.GetParameters;

public record ParameterResponse(int Id, string Name);

public record GetParametersResponse(
    List<ParameterResponse> LoanReason,
    List<ParameterResponse> Indication,
    List<ParameterResponse> BusinessSize);