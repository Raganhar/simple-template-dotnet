using FluentAssertions;
using NSubstitute;
using Tests.TestFixtures;
using webapi.Controllers.Public.Product.V1.Handlers.CreateProduct;
using webapi.Controllers.Public.Product.V1.Handlers.CreateProduct.Dao;
using webapi.Controllers.Public.Product.V1.Handlers.CreateProduct.RandomLogic;
using webapi.Controllers.Public.Product.V1.Handlers.CreateProduct.Request;
using webapi.Events.EventHandlers.Private.ProductTopic.UpdateProductSearchCache;
using webapi.Events.EventHandlers.Private.ProductTopic.UpdateProductSearchCache.Dao;
using webapi.Events.EventHandlers.Private.ProductTopic.UpdateProductSearchCache.RandomLogic;
using Xunit;

namespace Tests.EventHandlers.ProductTopic.UpdateProductSearchCacheTests.HandlerTests.HandlerFlowTests;

public class UpdateProductSearchCacheHandlerTests
{
    [Test]
    public async Task HappyPath()
    {
        //Setup: mock all dependencies
        var createProductDao = Substitute.For<IUpdateProductSearchCacheDao>();
        var createProductBusinessMagic = Substitute.For<IUpdateProductSearchCacheBusinessMagic>();
        var handler = new UpdateProductSearchCacheHandler(createProductDao,createProductBusinessMagic);

        createProductDao.GetData(Arg.Any<Guid>()).ReturnsForAnyArgs(Task.FromResult(new {}));
        createProductBusinessMagic.SomeLogic().ReturnsForAnyArgs(Task.FromResult(true));
        createProductBusinessMagic.SomeOtherLogic(Arg.Any<object>()).ReturnsForAnyArgs(Task.FromResult(true));

        //execute
        var createProductRequest = new CreateProductRequest();
        await handler.Execute(createProductRequest);

        //assert
        // check mocks to validate it did what was expected
    }
    
    [Test]
    public async Task SomethingIsWrong()
    {
        //Setup: mock all dependencies
        var createProductDao = Substitute.For<IUpdateProductSearchCacheDao>();
        var createProductBusinessMagic = Substitute.For<IUpdateProductSearchCacheBusinessMagic>();
        var handler = new UpdateProductSearchCacheHandler(createProductDao,createProductBusinessMagic);

        createProductDao.GetData(Arg.Any<Guid>()).ReturnsForAnyArgs(Task.FromResult(new {}));
        createProductBusinessMagic.SomeLogic().ReturnsForAnyArgs(Task.FromResult(true));
        createProductBusinessMagic.SomeOtherLogic(Arg.Any<object>()).ReturnsForAnyArgs(Task.FromResult(true));

        //execute
        var createProductRequest = new CreateProductRequest();
        await handler.Execute(createProductRequest);

        //assert
        // check mocks to validate it did what was expected
    }
}