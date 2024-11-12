namespace ApiGiroComVeiculo.Api.Common.Exceptions;

public class BadRequestException : Exception
{
    public Dictionary<string, List<string>> Errors { get; }

    public BadRequestException() : base("The server could not understand the request due to invalid syntax.")
    {
    }

    public BadRequestException(string message) : base(message)
    {
    }

    public BadRequestException(Dictionary<string, List<string>> errors)
        : base("Validation failed for one or more fields.")
    {
        Errors = errors ?? [];
    }

    public BadRequestException(string message, Dictionary<string, List<string>> errors)
        : base(message)
    {
        Errors = errors ?? [];
    }
}