using MediatR;

namespace ApiGiroComVeiculo.Api.Features.Auth.Login;

public record LoginCommand(string Cnpj, string Plate) : IRequest<LoginResponse>;