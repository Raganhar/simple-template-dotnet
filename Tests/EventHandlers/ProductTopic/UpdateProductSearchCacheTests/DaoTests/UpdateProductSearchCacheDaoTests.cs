using FluentAssertions;
using Tests.TestFixtures;
using webapi.EventHandlers.ProductTopic.UpdateProductSearchCache.Dao;
using Xunit;

namespace Tests.EventHandlers.ProductTopic.UpdateProductSearchCacheTests.DaoTests;

[Collection(nameof(IntegrationTestFixture))]
public class UpdateProductSearchCacheDaoTests
{
    private readonly TestWebApplicationFactory _factory;
    private readonly IUpdateProductSearchCacheDao _dao;
    private readonly object _db; //TODO: replace with example dbContext

    public UpdateProductSearchCacheDaoTests(TestWebApplicationFactory factory)
    {
        _factory = factory;

        _dao = _factory.GetService<IUpdateProductSearchCacheDao>();
        //TODO: mock handler / external auth dependencies
        _db = _factory.GetService<object>();
    }

    [Test]
    public async Task LoadDataCorrectly()
    {
        //Setup
        // seed database
        var guid = new Guid();//Guid from db
        
        //execute
        var data = await _dao.GetData(guid);
        
        //assert
        data.Should().Be("");// expected data
    }
    
    [Test]
    public async Task MissingDataCase()
    {
        //Setup
        // seed database
        var guid = new Guid();//Guid from db
        
        //execute
        var data = await _dao.GetData(guid);
        
        //assert
        data.Should().Be("");// expected data
    }
    
    //TODO: discuss how to verify we limit result sets to not load everything
    [Test]
    public async Task DontLoadAllDataInTheDatabaseCase()
    {
        //Setup
        // seed database
        var guid = new Guid();//Guid from db
        
        //execute
        var data = await _dao.GetData(guid);
        
        //assert
        data.Should().Be("");// expected data
    }
}