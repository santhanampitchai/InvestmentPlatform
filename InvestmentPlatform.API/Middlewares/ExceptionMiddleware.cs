using System.Net;
using System.Text.Json;
using InvestmentPlatform.Domain.Exceptions;
using FluentValidation;
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(
        RequestDelegate next,
        ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception occurred.");

            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(
        HttpContext context,
        Exception exception)
    {
        context.Response.ContentType = "application/json";

        var response = new object();
        var statusCode = HttpStatusCode.InternalServerError;

        switch (exception)
        {
            case DomainException domainEx:
                statusCode = HttpStatusCode.BadRequest;
                response = new
                {
                    error = domainEx.ErrorCode,
                    message = domainEx.Message
                };
                break;

            case ValidationException validationEx:
                statusCode = HttpStatusCode.BadRequest;
                response = new
                {
                    error = "VALIDATION_ERROR",
                    message = validationEx.Errors.Select(e => e.ErrorMessage)
                };
                break;

            default:
                response = new
                {
                    error = "SERVER_ERROR",
                    message = "An unexpected error occurred."
                };
                break;
        }

        context.Response.StatusCode = (int)statusCode;

        await context.Response.WriteAsync(
            JsonSerializer.Serialize(response));
    }
}
