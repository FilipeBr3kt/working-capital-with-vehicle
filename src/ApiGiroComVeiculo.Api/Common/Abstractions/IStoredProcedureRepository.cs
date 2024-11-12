using ApiGiroComVeiculo.Api.Common.DTOs;
using ApiGiroComVeiculo.Api.Common.Responses;

namespace ApiGiroComVeiculo.Api.Common.Abstractions;

public interface IStoredProcedureRepository
{
    Task<ValidateProtocolProcedureResponse> VerifyUserInformation(VerifyUserInformationDTO model,
        CancellationToken cancellationToken);

    Task<InsertProtocolProcedureResponse> InsertProtocolAsync(InsertProtocolDTO model,
        CancellationToken cancellation);
}
