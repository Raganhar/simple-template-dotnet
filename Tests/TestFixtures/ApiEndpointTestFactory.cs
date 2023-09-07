using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using webapi.Services.Caching;

namespace Tests.TestFixtures;

public class ApiEndpointTestFactory
    : WebApplicationFactory<DistributedCache>
{
    public T GetService<T>()
    {
        return Services.CreateScope().ServiceProvider.GetRequiredService<T>();
    }

    public List<T> GetServices<T>()
    {
        return Services.CreateScope().ServiceProvider.GetServices<T>().ToList();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            // replace stuff with mocks
            // etc.
        });
    }
}