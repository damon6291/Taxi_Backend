using Taxi_Backend.Data;
using Taxi_Backend.Managers;
using Taxi_Backend.Models;
using System.Threading;

public class BackgroundWorkerServiceMatching : BackgroundService
{
    readonly ILogger<BackgroundWorkerServiceMatching> _logger;
    private readonly IServiceScopeFactory _factory;

    public BackgroundWorkerServiceMatching(ILogger<BackgroundWorkerServiceMatching> logger, IServiceScopeFactory factory)
    {
        _logger = logger;
        _factory = factory;

    }

    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await using AsyncServiceScope asyncScope = _factory.CreateAsyncScope();
            var manager = asyncScope.ServiceProvider.GetRequiredService<BackgroundManager>();
            await manager.MatchAllCustomerAndDriverQueues();
            await Task.Delay(5000, stoppingToken); // 5sec
        }
    }
}