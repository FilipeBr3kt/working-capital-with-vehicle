using ApiGiroComVeiculo.Api.Features.Auth.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiGiroComVeiculo.Api.Features.Parameters.GetParameters;

public static class LoginEndpoint
{
    public static void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("login", async ([FromBody] LoginCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            return Results.Ok(result);
        }).AllowAnonymous();
    }
}