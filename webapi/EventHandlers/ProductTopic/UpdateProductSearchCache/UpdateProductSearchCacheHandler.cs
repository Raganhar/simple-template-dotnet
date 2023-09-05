using webapi.EventHandlers.ProductTopic.UpdateProductSearchCache.Dao;
using webapi.EventHandlers.ProductTopic.UpdateProductSearchCache.RandomLogic;

namespace webapi.EventHandlers.ProductTopic.UpdateProductSearchCache;

public class UpdateProductSearchCacheHandler
{
    private IUpdateProductSearchCacheDao _productDao;
    private IUpdateProductSearchCacheBusinessMagic _businessMagic;

    public UpdateProductSearchCacheHandler(IUpdateProductSearchCacheDao productDao, IUpdateProductSearchCacheBusinessMagic businessMagic)
    {
        _productDao = productDao;
        _businessMagic = businessMagic;
    }

    public async Task Execute(object request)
    {
        var product = await _productDao.GetData(Guid.Empty);
        if (product is null)
        {
            throw new Exception("something is invalid");
        }

        if (await _businessMagic.SomeLogic())
        {
            throw new ArgumentException("something ");
        }

        var someOtherLogic = await _businessMagic.SomeOtherLogic(request);
        if (!someOtherLogic)
        {
            throw new Exception("Failed to update stuff");
        }
    }
}