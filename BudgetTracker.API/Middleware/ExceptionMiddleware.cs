using BudgetTracker.Core.Exceptions;
using FluentValidation;
using System.Net;

namespace BudgetTracker.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
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
                _logger.LogError(ex, "Wystąpił nieobsłużony błąd: {Message}", ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var response = new { error = "Wystąpił błąd serwera." };

            switch (exception)
            {
                case ValidationException validationEx:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                    var errors = validationEx.Errors.Select(e => e.ErrorMessage).ToList();
                    return context.Response.WriteAsJsonAsync(new { error = "Błąd walidacji", details = errors });

                case EntityNotFoundException:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    response = new { error = exception.Message };
                    break;

                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            return context.Response.WriteAsJsonAsync(response);
        }
    }
}
