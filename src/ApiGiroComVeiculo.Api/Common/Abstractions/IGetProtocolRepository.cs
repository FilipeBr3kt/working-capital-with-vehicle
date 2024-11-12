using ApiGiroComVeiculo.Api.Common.Responses;

namespace ApiGiroComVeiculo.Api.Common.Abstractions;

public interface IGetProtocolRepository
{
    Task<List<GetProtocolResponseView>> GetProtocolAsync(string CPNJ, CancellationToken cancellationToken);
}
