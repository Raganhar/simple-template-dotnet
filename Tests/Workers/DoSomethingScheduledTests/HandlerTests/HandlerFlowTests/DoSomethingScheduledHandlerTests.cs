using FluentAssertions;
using NSubstitute;
using Tests.TestFixtures;
using webapi.Controllers.Public.Product.V1.Handlers.CreateProduct;
using webapi.Controllers.Public.Product.V1.Handlers.CreateProduct.Dao;
using webapi.Controllers.Public.Product.V1.Handlers.CreateProduct.RandomLogic;
using webapi.Controllers.Public.Product.V1.Handlers.CreateProduct.Request;
using Xunit;

namespace Tests.Workers.DoSomethingScheduledTests.HandlerTests.HandlerFlowTests;

[Collection(nameof(VertricalTestFixture))]
public class DoSomethingScheduledHandlerTests
{
    [Test]
    public async Task HappyPath()
    {
        //Setup: mock all dependencies
        var createProductDao = Substitute.For<ICreateProductDao>();
        var createProductBusinessMagic = Substitute.For<ICreateProductBusinessMagic>();
        var handler = new CreateProductHandler(createProductDao,createProductBusinessMagic);

        createProductDao.GetData(Arg.Any<Guid>()).ReturnsForAnyArgs(Task.FromResult(new {}));
        createProductBusinessMagic.SomeLogic().ReturnsForAnyArgs(Task.FromResult(true));
        createProductBusinessMagic.SomeOtherLogic(Arg.Any<object>()).ReturnsForAnyArgs(Task.FromResult(new {}));

        //execute
        var createProductRequest = new CreateProductRequest();
        var execute = await handler.Execute(createProductRequest);

        //assert
        execute.Item2.Should().Be(CreateProductHandlerResult.success);
        execute.Item1.Should().BeEquivalentTo(new { });
    }
    
    [Test]
    public async Task SomethingIsWrong()
    {
        //Setup: mock all dependencies
        var createProductDao = Substitute.For<ICreateProductDao>();
        var createProductBusinessMagic = Substitute.For<ICreateProductBusinessMagic>();
        var handler = new CreateProductHandler(createProductDao,createProductBusinessMagic);

        createProductDao.GetData(Arg.Any<Guid>()).ReturnsForAnyArgs(Task.FromResult(new {}));
        createProductBusinessMagic.SomeLogic().ReturnsForAnyArgs(Task.FromResult(true));
        createProductBusinessMagic.SomeOtherLogic(Arg.Any<object>()).ReturnsForAnyArgs(Task.FromResult(new {}));

        //execute
        var createProductRequest = new CreateProductRequest();
        var execute = await handler.Execute(createProductRequest);

        //assert
        execute.Item2.Should().Be(CreateProductHandlerResult.misconfigured);
        execute.Item1.Should().BeNull();
    }
}