using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiGiroComVeiculo.Api.Features.Protocol.CreateProtocol;

public static class CreateProtocolEnpoint
{
    public static void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("insert-protocol", async ([FromBody] CreateProtocolCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            return Results.Created("Protocol created successfully", result);
        });
    }
}