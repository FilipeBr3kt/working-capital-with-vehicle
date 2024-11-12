using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace ApiGiroComVeiculo.Api.Features.Parameters.GetParameters;

public static class GetParametersEndpoint
{
    public static void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("parameters", async (IDistributedCache cache, ISender sender) =>
        {
            string key = "parameters";
            var cachedValue = await cache.GetStringAsync(key);

            if (!string.IsNullOrEmpty(cachedValue))
            {
                var parameters = JsonSerializer.Deserialize<IEnumerable<GetParametersResponse>>(cachedValue);
                if (parameters is not null)
                {
                    return Results.Ok(parameters);
                }
            }

            var command = new GetParametersQuery();
            var result = await sender.Send(command);
            return Results.Ok(result);
        });
    }
}