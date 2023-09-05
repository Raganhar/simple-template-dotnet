namespace webapi.Services.Caching;

public interface IDistributedCache
{
    Task<T> Get<T>(string key);
    Task<bool> Update(string key, object data);
}

public class DistributedCache : IDistributedCache
{
    public async Task<T> Get<T>(string key)
    {
        return await Task.FromResult(default(T));
    }

    public Task<bool> Update(string key, object data)
    {
        throw new NotImplementedException();
    }
}