using FluentAssertions;
using webapi.Services.Abc234Api;

namespace Tests.Integrations.Abc234Api.Abc234Api.IntegrationTests;

public class GetDataIntegationTests
{
    private Abc234IntegrationService _service;

    public GetDataIntegationTests()
    {
        _service = new Abc234IntegrationService();
    }

    [Test]
    public async Task GetData_404()
    {
        var data = await _service.GetData();
        data.Should().BeNull();
        //verify we handle 404s correctly in integration service
    }

    [Test]
    public async Task GetData_401()
    {
        var data = await _service.GetData();
        data.Should().BeNull();
        //verify we handle 401s correctly in integration service
    }

    [Test]
    public async Task GetData_Success()
    {
        var data = await _service.GetData();
        data.Name.Should().Be("bobby");
    }
}