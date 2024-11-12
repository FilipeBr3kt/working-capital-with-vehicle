using MediatR;

namespace ApiGiroComVeiculo.Api.Features.Protocol.GetProtocol;

public record GetProtocolQuery : IRequest<GetProtocolResponse>;
