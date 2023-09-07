using webapi.Events.EventHandlers.Private.ProductTopic.UpdateProductSearchCache.Dao;
using webapi.Events.EventHandlers.Private.ProductTopic.UpdateProductSearchCache.RandomLogic;

namespace webapi.Workers.DoSomethingScheduled;

public class DoSomethingScheduledWorker : IHostedService
{
    private IServiceProvider _serviceProvider;

    public DoSomethingScheduledWorker( IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        // _logger.LogInformation($"{nameof(ProductTypePropertyHydrator)} scheduling job");
        // FluentScheduler.JobManager.AddJob(async () => _serviceProvider.CreateScope().GetService<DoSomethingScheduledHandler>().Execute();, s => s.ToRunNow().AndEvery(JobExecutingInterval).Hours());
        // _logger.LogInformation($"{nameof(ProductTypePropertyHydrator)} scheduled job");
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        // _logger.LogInformation($"{nameof(ProductTypePropertyHydrator)} stopping job");
        // FluentScheduler.JobManager.Stop();
        // _logger.LogInformation($"{nameof(ProductTypePropertyHydrator)} stopped job");
        return Task.CompletedTask;
    }
}