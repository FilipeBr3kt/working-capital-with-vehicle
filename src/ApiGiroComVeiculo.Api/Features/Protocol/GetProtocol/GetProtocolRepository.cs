using ApiGiroComVeiculo.Api.Common.Abstractions;
using ApiGiroComVeiculo.Api.Common.Responses;
using ApiGiroComVeiculo.Api.Database;
using Microsoft.EntityFrameworkCore;

namespace ApiGiroComVeiculo.Api.Features.Protocol.GetProtocol;

public class GetProtocolRepository : IGetProtocolRepository
{
    private readonly DatabaseContext _databaseContext;

    public GetProtocolRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<List<GetProtocolResponseView>> GetProtocolAsync(string CPNJ, CancellationToken cancellationToken)
    {
        return await _databaseContext.VwApiT2208P1s
            .Where(p => p.InsFederal == CPNJ)
            .Select(p => new GetProtocolResponseView
            {
                Id = p.Id ?? 0,
                NrProtocol = p.NrProtocolo!,
                DateRegister = p.DhRegistro ?? DateTime.MinValue,
                Document = p.InsFederal!,
                Name = p.Nome!,
                PhoneDdd = (int)p.FonDdd!,
                PhoneNumber = p.FonNum!,
                RequestedValue = (int)p.VlSolicitado!,
                Plate = p.VeiPlaca!,
                Type = (int)p.DmTipo!,
                Status = (int)p.DmStatus!,
                Situation = (int)p.DmSituacao!
            }).ToListAsync(cancellationToken);
    }
}
