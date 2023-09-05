using FluentAssertions;
using Tests.TestFixtures;
using webapi.Controllers.Public.Product.V1.Handlers.CreateProduct.Dao;
using Xunit;

namespace Tests.Controllers.Public.V1.Handlers.CreateProductTests.DaoTests;

[Collection(nameof(IntegrationTestFixture))]
public class CreateProductDaoTests
{
    private readonly TestWebApplicationFactory _factory;
    private readonly ICreateProductDao _dao;
    private readonly object _db; //TODO: replace with example dbContext

    public CreateProductDaoTests(TestWebApplicationFactory factory)
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