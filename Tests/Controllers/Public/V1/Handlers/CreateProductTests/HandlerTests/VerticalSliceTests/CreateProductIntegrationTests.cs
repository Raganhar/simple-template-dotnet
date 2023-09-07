using FluentAssertions;
using Flurl.Http;
using Tests.TestFixtures;
using webapi.Controllers.Public.Product.V1.Handlers.CreateProduct;
using webapi.Controllers.Public.Product.V1.Handlers.CreateProduct.Request;
using Xunit;

namespace Tests.Controllers.Public.V1.Handlers.CreateProductTests.HandlerTests.VerticalSliceTests;

[Collection(nameof(VertricalTestFixture))]
public class CreateProductIntegrationTests
{
    private readonly IFlurlRequest _flurlRequest;
    private readonly VerticalTestFactory _factory;
    private object _db;
    private readonly CreateProductHandler _handler;

    public CreateProductIntegrationTests(VerticalTestFactory factory)
    {
        _factory = factory;

        var flurlClient = new FlurlClient(factory.Server.CreateClient());
        _flurlRequest = flurlClient.WithHeader(SwaggerConsts.Api_key_header_name, "bob")
            .Request("public/v1/product");

        _db = _factory.GetService<object>();
        _handler = _factory.GetService<CreateProductHandler>();
    }

    [Test]
    public async Task HappyPath()
    {
        //Setup
        // prepare db
        var createProductRequest = new CreateProductRequest();

        //execute
        var execute = await _handler.Execute(createProductRequest);

        //assert
        
        execute.Item2.Should().Be(CreateProductHandlerResult.success);
        execute.Item1.Should().BeEquivalentTo(new { });
        
        // check state in db etc 
    }
}