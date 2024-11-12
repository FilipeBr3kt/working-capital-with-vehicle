using ApiGiroComVeiculo.Api.Common.Abstractions;
using ApiGiroComVeiculo.Api.Common.Constants;
using ApiGiroComVeiculo.Api.Common.Exceptions;
using MediatR;

namespace ApiGiroComVeiculo.Api.Features.Parameters.GetParameters;

public class GetParametersQueryHandler : IRequestHandler<GetParametersQuery, GetParametersResponse>
{
    private readonly IParametersRepository _repository;

    public GetParametersQueryHandler(IParametersRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetParametersResponse> Handle(GetParametersQuery request, CancellationToken cancellationToken)
    {
        var indicationResult = await _repository.GetIndicationAsync(cancellationToken);
        var loanReasonResult = await _repository.GetReasonAsync(cancellationToken);
        var businessSizeResult = BusinessSize.GetBusinessSize();

        if (!indicationResult.Any() || !loanReasonResult.Any() || !businessSizeResult.Any())
        {
            throw new NotFoundException("Parameters not found");
        }

        return new GetParametersResponse(
            indicationResult.Select(i => new ParameterResponse(i.Id, i.Nome)).ToList(),
            businessSizeResult.Select(b => new ParameterResponse(b.Id, b.Name)).ToList(),
            loanReasonResult.Select(l => new ParameterResponse(l.Id, l.NmMotivo!)).ToList()
        );
    }
}