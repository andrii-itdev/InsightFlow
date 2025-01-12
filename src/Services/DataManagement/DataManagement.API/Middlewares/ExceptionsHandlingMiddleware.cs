namespace DataManagement.API.Middlewares
{
    using Microsoft.AspNetCore.WebUtilities;
    using Microsoft.Net.Http.Headers;
    using Serilog;
    using System.Net.Mime;

    public class ExceptionsHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionsHandlingMiddleware(RequestDelegate requestDelegate, ILogger logger)
        {
            _next = requestDelegate;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(HttpRequestException ex)
            {
                _logger.Error(ex, $"{nameof(HttpClient)} request failed.", nameof(ExceptionsHandlingMiddleware));
                context.Response.Headers[HeaderNames.ContentType] = MediaTypeNames.Application.Json;
                context.Response.StatusCode = (int?)ex.StatusCode ?? StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsJsonAsync(GetErrorMessage(ex.Message, context.Response.StatusCode));
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An exception is captured in {0}", nameof(ExceptionsHandlingMiddleware));
                context.Response.Headers[HeaderNames.ContentType] = MediaTypeNames.Application.Json;
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsJsonAsync(GetErrorMessage(ex.Message, context.Response.StatusCode));
            }
        }

        private static string GetErrorMessage(string message, int code)
        {
            return @$"{code} {ReasonPhrases.GetReasonPhrase(code)} {message}";
        }
    }
}
