namespace ApiGiroComVeiculo.Api.Common.Exceptions;

public class UnauthorizedException : Exception
{
    public UnauthorizedException() : base("Authentication is required and has failed or has not yet been provided.")
    {
    }

    public UnauthorizedException(string message) : base(message)
    {
    }
}