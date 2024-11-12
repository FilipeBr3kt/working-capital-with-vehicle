namespace ApiGiroComVeiculo.Api.Common.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException() : base("The requested resource could not be found on this server.")
    {
    }

    public NotFoundException(string message) : base(message)
    {
    }
}
