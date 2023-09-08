using FluentAssertions;
using Tests.TestFixtures;
using webapi.Controllers.Public.Product.V1.Handlers.CreateProduct.Dao;
using Xunit;

namespace Tests.Workers.DoSomethingScheduledTests.DaoTests;

[Collection(nameof(VertricalTestFixture))]
public class DoSomethingScheduledDaoTests
{
    private readonly DaoTestFactory _factory;
    private readonly ICreateProductDao _dao;
    private readonly object _db; //TODO: replace with example dbContext

    public DoSomethingScheduledDaoTests(DaoTestFactory factory)
    {
        _factory = factory;

        _dao = _factory.GetService<ICreateProductDao>();
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