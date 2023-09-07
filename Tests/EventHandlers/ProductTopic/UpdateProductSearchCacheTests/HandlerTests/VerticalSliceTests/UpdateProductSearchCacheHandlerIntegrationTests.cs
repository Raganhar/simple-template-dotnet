using FluentAssertions;
using Flurl.Http;
using Tests.TestFixtures;
using webapi.Controllers.Public.Product.V1.Handlers.CreateProduct;
using webapi.Controllers.Public.Product.V1.Handlers.CreateProduct.Request;
using webapi.Events.EventHandlers.Private.ProductTopic.UpdateProductSearchCache;
using Xunit;

namespace Tests.EventHandlers.ProductTopic.UpdateProductSearchCacheTests.HandlerTests.VerticalSliceTests;

[Collection(nameof(VertricalTestFixture))]
public class UpdateProductSearchCacheHandlerIntegrationTests
{
    private readonly VerticalTestFactory _factory;
    private object _db;
    private readonly UpdateProductSearchCacheHandler _handler;

    public UpdateProductSearchCacheHandlerIntegrationTests(VerticalTestFactory factory)
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