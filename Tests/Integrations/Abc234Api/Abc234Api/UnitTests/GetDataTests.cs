using System.Net;
using FluentAssertions;
using Flurl.Http.Testing;
using webapi.Services.Abc234Api;
using webapi.Services.Abc234Api.IntegrationModels;

namespace Tests.Integrations.Abc234Api.Abc234Api.UnitTests;

public class GetDataTests
{
    private Abc234IntegrationService _service;

    public GetDataTests()
    {
        _service = new Abc234IntegrationService();
    }
    [Test]
    public async Task GetData_404()
    {
        using (var httpTest = new HttpTest())
        {
            httpTest.RespondWith(string.Empty, (int)HttpStatusCode.NotFound);
            var data = await _service.GetData();
            data.Should().BeNull();
            //verify we handle 404s correctly in integration service
        }
    }
    
    [Test]
    public async Task GetData_401()
    {
        using (var httpTest = new HttpTest())
        {
            httpTest.RespondWith(string.Empty, (int)HttpStatusCode.Unauthorized);
            var data = await _service.GetData();
            data.Should().BeNull();
            //verify we handle 401s correctly in integration service
        }
    }
    
    [Test]
    public async Task GetData_Timeout()
    {
        using (var httpTest = new HttpTest())
        {
            httpTest.SimulateTimeout();
            var data = await _service.GetData();
            //verify we handle timeout correctly in integration service
        }
    }
    [Test]
    public async Task GetData_Success()
    {
        using (var httpTest = new HttpTest())
        {
            httpTest.RespondWithJson(new SomeResponseModel()
            {
                Name = "bobby"
            });
            var data = await _service.GetData();
            data.Name.Should().Be("bobby");
        }
    }
}