using Infrastructure.Logging;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly LogErrorRepository _logger;

    public ExceptionMiddleware(RequestDelegate next, LogErrorRepository logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var erro = new LogErro(ex.Message, ex.StackTrace);
            // Log the exception
            var codErro = await _logger.LogError(erro);

            // Handle the exception (e.g., return an error response to the client)
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync($"Código Erro: {codErro}.");
        }
    }
}

