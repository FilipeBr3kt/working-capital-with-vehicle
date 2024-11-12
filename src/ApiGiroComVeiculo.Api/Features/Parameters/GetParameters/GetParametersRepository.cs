using ApiGiroComVeiculo.Api.Common.Abstractions;
using ApiGiroComVeiculo.Api.Database;
using ApiGiroComVeiculo.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ApiGiroComVeiculo.Api.Features.Parameters.GetParameters;

public class GetParametersRepository : IParametersRepository
{
    private readonly Database.DatabaseContext _dbContext;

    public GetParametersRepository(Database.DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<T1017>> GetIndicationAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.T1017s
            .AsNoTracking()
            .Where(i => i.DmStatus == 1)
            .OrderBy(i => i.NrSeq)
            .ThenBy(i => i.Nome)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<VwT1213B1>> GetReasonAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.VwT1213B1s
            .AsNoTracking()
            .Where(v => v.FkT1201 == 13)
            .OrderBy(v => v.NrSeq)
            .ThenBy(v => v.NmMotivo)
            .ToListAsync(cancellationToken);
    }
}