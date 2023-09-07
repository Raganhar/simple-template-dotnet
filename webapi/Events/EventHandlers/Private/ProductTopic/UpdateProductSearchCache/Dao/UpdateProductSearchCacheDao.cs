namespace webapi.Events.EventHandlers.Private.ProductTopic.UpdateProductSearchCache.Dao;

public interface IUpdateProductSearchCacheDao
{
    Task<object> GetData(Guid id);
}

public class UpdateProductSearchCacheDao : IUpdateProductSearchCacheDao
{
    public async Task<object> GetData(Guid id)
    {
        // retrieve data from DB
        return (await Task.FromResult(null as object))!;
    }
}