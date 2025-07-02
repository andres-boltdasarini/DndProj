using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;


    public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LoggingMiddleware> _logger;

    public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var requestRepository = context.RequestServices.GetService<IRequestRepository>();
        string url = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}{context.Request.QueryString}";

        try
        {
            await requestRepository.LogRequestAsync(url);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Logging failed for URL: {Url}", url);
        }

        await _next(context);
    }
}
