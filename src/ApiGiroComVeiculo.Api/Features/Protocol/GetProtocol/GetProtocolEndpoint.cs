using MediatR;

namespace ApiGiroComVeiculo.Api.Features.Protocol.GetProtocol;

public static class GetProtocolEndpoint
{
    public static void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("get-protocol", async (ISender sender) =>
        {
            var query = new GetProtocolQuery();
            var result = await sender.Send(query);
            return Results.Ok(result);
        }).RequireAuthorization();
    }
}
