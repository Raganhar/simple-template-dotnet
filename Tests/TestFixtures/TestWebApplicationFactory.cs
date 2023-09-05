using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using webapi.Services.Caching;

namespace Tests.TestFixtures;

public class TestWebApplicationFactory
    : WebApplicationFactory<DistributedCache>
{
    private readonly MySqlTestcontainer _db = new TestcontainersBuilder<MySqlTestcontainer>()
        .WithDatabase(new MySqlTestcontainerConfiguration
        {
            Database = "ProductDatabase",
            Password = "root",
            Username = "root",
        })
        .WithImage("mysql:5.7.36")
        .Build();
    
    private readonly RedisTestcontainer _redis = new TestcontainersBuilder<RedisTestcontainer>()
        .WithDatabase(new RedisTestcontainerConfiguration())
        .Build();
    
    public TestWebApplicationFactory()
    {
        var db = _db.StartAsync();
        var redis = _redis.StartAsync();
        Task.WaitAll(db,redis);
    }
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
            // seed DBs
            // etc.
        });
    }
}