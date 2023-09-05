using System.Net;
using Flurl.Http;
using webapi.Services.Abc234Api.IntegrationModels;

namespace webapi.Services.Abc234Api;

public interface IAbc234IntegrationService
{
    Task<SomeResponseModel> GetData();
    Task<object> DoSomeStuff(object data);
}

public class Abc234IntegrationService : IAbc234IntegrationService
{
    public async Task<SomeResponseModel> GetData()
    {
        var jsonAsync = await "".GetAsync();
        switch (jsonAsync.StatusCode)
        {
            case (int)HttpStatusCode.Accepted: return await jsonAsync.GetJsonAsync<SomeResponseModel>();
            case (int)HttpStatusCode.NotFound:
                //TODO: some metrics stuff
                return null;
            case (int)HttpStatusCode.Unauthorized:
            case (int)HttpStatusCode.Forbidden:
                //TODO: some metrics stuff
                //TODO: alerting to new relic ?
                return null;
            default:
                throw new Exception("case not handled");
        }
    }
    
    public async Task<object> DoSomeStuff(object data)
    {
        var jsonAsync = await "".PostJsonAsync(data);
        switch (jsonAsync.StatusCode)
        {
            case (int)HttpStatusCode.Accepted: return jsonAsync.GetJsonAsync<object>();
            case (int)HttpStatusCode.NotFound:
                //TODO: some metrics stuff
                return null;
            case (int)HttpStatusCode.Unauthorized:
            case (int)HttpStatusCode.Forbidden:
                //TODO: some metrics stuff
                //TODO: alerting to new relic ?
                return null;
            default:
                throw new Exception("case not handled");
        }
    }
}