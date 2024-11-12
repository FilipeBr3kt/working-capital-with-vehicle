namespace ApiGiroComVeiculo.Api.Common.Exceptions;

public class InternalServerException : Exception
{
    public InternalServerException() : base(
        "The server encountered an unexpected condition that prevented it from fulfilling the request.")
    {
    }

    public InternalServerException(string message) : base(message)
    {
    }
}
