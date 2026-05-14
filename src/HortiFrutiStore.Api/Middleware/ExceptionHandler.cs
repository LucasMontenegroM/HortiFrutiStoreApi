using HortiFrutiStore.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace HortiFrutiStore.Api.Exceptions;

internal sealed class ExceptionHandler : IExceptionHandler
{
    private readonly ILogger<ExceptionHandler> _logger;

    public ExceptionHandler(ILogger<ExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Exceção não tratada ocorreu.");

        httpContext.Response.StatusCode = exception switch
        {
            NotFoundException  => StatusCodes.Status404NotFound,
            DomainException    => StatusCodes.Status400BadRequest,
            AppException       => StatusCodes.Status400BadRequest,
            _                  => StatusCodes.Status500InternalServerError
        };

        await httpContext.Response.WriteAsJsonAsync(new
        {
            status = httpContext.Response.StatusCode,
            message = exception.Message
        }, cancellationToken);

        return true;
    }
}
