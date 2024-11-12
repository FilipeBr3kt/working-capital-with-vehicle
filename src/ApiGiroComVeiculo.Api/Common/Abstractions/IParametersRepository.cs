using ApiGiroComVeiculo.Api.Entities;

namespace ApiGiroComVeiculo.Api.Common.Abstractions;

public interface IParametersRepository
{
    Task<IEnumerable<T1017>> GetIndicationAsync(CancellationToken cancellationToken);
    Task<IEnumerable<VwT1213B1>> GetReasonAsync(CancellationToken cancellationToken);
}