using ApiGiroComVeiculo.Api.Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ApiGiroComVeiculo.Api.Middlewares;

public class ExceptionToProblemDetailsHandler : IExceptionHandler
{
    private static readonly Dictionary<Type, (int StatusCode, string Type, string Title)> ExceptionDetails = new()
    {
        {
            typeof(BadRequestException),
            (StatusCodes.Status400BadRequest, "https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Status/400",
                "Bad Request")
        },
        {
            typeof(NotFoundException),
            (StatusCodes.Status404NotFound, "https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Status/404", "Not Found")
        },
        {
            typeof(ConflictException),
            (StatusCodes.Status409Conflict, "https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Status/409", "Conflict")
        },
        {
            typeof(ForbiddenException),
            (StatusCodes.Status403Forbidden, "https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Status/403",
                "Forbidden")
        },
        {
            typeof(InternalServerException),
            (StatusCodes.Status500InternalServerError, "https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Status/500",
                "Internal Server Error")
        },
        {
            typeof(ServiceUnavailableException),
            (StatusCodes.Status503ServiceUnavailable, "https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Status/503",
                "Service Unavailable")
        },
        {
            typeof(TooManyRequestsException),
            (StatusCodes.Status429TooManyRequests, "https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Status/429",
                "Too Many Requests")
        },
        {
            typeof(UnauthorizedException),
            (StatusCodes.Status401Unauthorized, "https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Status/401",
                "Unauthorized")
        }
    };

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        var exceptionType = exception.GetType();
        var (statusCode, type, title) = ExceptionDetails.GetValueOrDefault(exceptionType,
            (StatusCodes.Status500InternalServerError,
                "https://datatracker.ietf.org/doc/html/rfc9110#name-500-internal-server-error",
                "Internal Server Error"));

        var problemDetails = new ProblemDetails
        {
            Title = title,
            Detail = exception.Message,
            Type = type,
            Status = statusCode,
        };

        if (exception is BadRequestException badRequestException && badRequestException.Errors != null)
        {
            problemDetails.Extensions["errors"] = badRequestException.Errors;
        }

        httpContext.Response.StatusCode = statusCode;
        httpContext.Response.ContentType = "application/problem+json";
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken: cancellationToken);

        return true;
    }
}