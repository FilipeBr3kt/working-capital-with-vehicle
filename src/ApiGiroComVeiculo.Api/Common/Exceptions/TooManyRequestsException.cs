namespace ApiGiroComVeiculo.Api.Common.Exceptions;

public class TooManyRequestsException : Exception
{
    public TooManyRequestsException() : base("The user has sent too many requests in a given amount of time.")
    {
    }

    public TooManyRequestsException(string message) : base(message)
    {
    }
}
