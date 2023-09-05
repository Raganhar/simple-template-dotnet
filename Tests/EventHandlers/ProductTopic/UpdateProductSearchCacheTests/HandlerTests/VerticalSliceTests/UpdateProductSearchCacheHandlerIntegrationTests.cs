using FluentAssertions;
using Flurl.Http;
using Tests.TestFixtures;
using webapi.Controllers.Public.Product.V1.Handlers.CreateProduct;
using webapi.Controllers.Public.Product.V1.Handlers.CreateProduct.Request;
using webapi.EventHandlers.ProductTopic.UpdateProductSearchCache;
using Xunit;

namespace Tests.EventHandlers.ProductTopic.UpdateProductSearchCacheTests.HandlerTests.VerticalSliceTests;

[Collection(nameof(IntegrationTestFixture))]
public class UpdateProductSearchCacheHandlerIntegrationTests
{
    private readonly TestWebApplicationFactory _factory;
    private object _db;
    private readonly UpdateProductSearchCacheHandler _handler;

    public UpdateProductSearchCacheHandlerIntegrationTests(TestWebApplicationFactory factory)
    {
        _factory = factory;
        _db = _factory.GetService<object>();
        _handler = _factory.GetService<UpdateProductSearchCacheHandler>();
    }

    [Test]
    public async Task HappyPath()
    {
        //Setup
        // prepare db
        var createProductRequest = new CreateProductRequest();

        //execute
        await _handler.Execute(createProductRequest);

        //assert
        // should not throw exception
        // check state in db etc 
    }
}