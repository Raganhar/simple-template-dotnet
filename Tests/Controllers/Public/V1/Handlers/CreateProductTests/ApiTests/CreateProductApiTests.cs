using FluentAssertions;
using Flurl.Http;
using Tests.TestFixtures;
using webapi.Controllers.Public.Product.V1.Handlers.CreateProduct;
using webapi.Controllers.Public.Product.V1.Handlers.CreateProduct.Request;
using webapi.Controllers.Public.Product.V1.Handlers.CreateProduct.Response;
using Xunit;

namespace Tests.Controllers.Public.V1.Handlers.CreateProductTests.ApiTests;

[Collection(nameof(IntegrationTestFixture))]
public class CreateProductApiTests
{
    private readonly IFlurlRequest _flurlRequest;
    private readonly TestWebApplicationFactory _factory;
    private readonly CreateProductHandler _handler;

    public CreateProductApiTests(TestWebApplicationFactory factory)
    {
        _factory = factory;

        var flurlClient = new FlurlClient(factory.Server.CreateClient());
        _flurlRequest = flurlClient.WithHeader(SwaggerConsts.Api_key_header_name, "bob")
            .Request("public/v1/product");//TODO: fix url

        _handler = _factory.GetService<CreateProductHandler>();
        //TODO: mock handler / external auth dependencies
    }

    [Test]
    public async Task ExpectedResponse_200()
    {
        //Setup
        // mock response from Handler
        var createProductRequest = new CreateProductRequest();

        //execute
        var response = await _flurlRequest.PostJsonAsync(createProductRequest);
        response.StatusCode.Should().Be(200);

        //assert

        var actualResponseModel = await response.GetJsonAsync<CreateProductResponse>();
        actualResponseModel.Should().NotBeNull();
        actualResponseModel.SomeResponseProp.Should().Be("whatever string");
    }
    
    [Test]
    public async Task ExpectedResponse_404()
    {
        //Setup
        // mock response from Handler
        var createProductRequest = new CreateProductRequest();

        //execute
        var response = await _flurlRequest.PostJsonAsync(createProductRequest);
        response.StatusCode.Should().Be(404);

        //assert

        var actualResponseModel = await response.GetJsonAsync<CreateProductResponse>();
        actualResponseModel.Should().BeNull();
    }
    
    [Test]
    public async Task ExpectedResponse_401()
    {
        //Setup
        // mock response from Handler
        var createProductRequest = new CreateProductRequest();

        //execute
        var response = await _flurlRequest.WithHeader(SwaggerConsts.Api_key_header_name, "not valid").PostJsonAsync(createProductRequest);
        response.StatusCode.Should().Be(401);

        //assert

        var actualResponseModel = await response.GetJsonAsync<CreateProductResponse>();
        actualResponseModel.Should().BeNull();
    }
}