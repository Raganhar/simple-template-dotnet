using webapi.Controllers.Public.Product.V1.Handlers.CreateProduct.Dao;
using webapi.Services.Caching;

namespace webapi.EventHandlers.ProductTopic.UpdateProductSearchCache.RandomLogic;

public interface IUpdateProductSearchCacheBusinessMagic
{
    Task<bool> SomeLogic();
    Task<bool> SomeOtherLogic(object data);
}

public class UpdateProductSearchCacheBusinessMagic : IUpdateProductSearchCacheBusinessMagic
{
    private IDistributedCache _distributedCache;

    public UpdateProductSearchCacheBusinessMagic(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }

    public Task<bool> SomeLogic()
    {
        return Task.FromResult(false);
    }

    public async Task<bool> SomeOtherLogic(object data)
    {
        /// random logic
        /// ..
        /// ..
        /// ..
        /// ..
        /// More logic
        
        var succeeded = await _distributedCache.Update("someKey",data);
        return succeeded;
    }
}