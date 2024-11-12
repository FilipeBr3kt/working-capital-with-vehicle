namespace ApiGiroComVeiculo.Api.Common.Exceptions;

public class ConflictException : Exception
{
    public ConflictException() : base(
        "The request could not be completed due to a conflict with the current state of the resource.")
    {
    }

    public ConflictException(string message) : base(message)
    {
    }
}
