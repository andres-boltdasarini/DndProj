public class RequestRepository : IRequestRepository
{
    private readonly ILogger<RequestRepository> _logger;

    public RequestRepository(ILogger<RequestRepository> logger)
    {
        _logger = logger;
    }

    public async Task LogRequestAsync(string url)
    {
        // Здесь может быть логика сохранения в базу данных, файл и т.д.
        // Для примера просто логируем
        _logger.LogInformation($"Request to: {url}");
        await Task.CompletedTask;
    }
}