using MediatR;

namespace ApiGiroComVeiculo.Api.Features.Parameters.GetParameters;

public record GetParametersQuery : IRequest<GetParametersResponse>;