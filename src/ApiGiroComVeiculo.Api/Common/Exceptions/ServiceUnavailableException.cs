namespace ApiGiroComVeiculo.Api.Common.Exceptions;

public class ServiceUnavailableException : Exception
{
    public ServiceUnavailableException() : base(
        "The server is not ready to handle the request. Common causes include maintenance or overloading.")
    {
    }

    public ServiceUnavailableException(string message) : base(message)
    {
    }
}
