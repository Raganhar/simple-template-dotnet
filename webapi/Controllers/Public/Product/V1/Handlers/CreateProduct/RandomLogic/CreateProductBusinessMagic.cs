using webapi.Controllers.Public.Product.V1.Handlers.CreateProduct.Dao;

namespace webapi.Controllers.Public.Product.V1.Handlers.CreateProduct.RandomLogic;

public interface ICreateProductBusinessMagic
{
    Task<bool> SomeLogic();
    Task<object> SomeOtherLogic(object data);
}

public class CreateProductBusinessMagic : ICreateProductBusinessMagic
{
    private ICreateProductDao _productDao;

    public CreateProductBusinessMagic(ICreateProductDao productDao)
    {
        _productDao = productDao;
    }

    public Task<bool> SomeLogic()
    {
        return Task.FromResult(false);
    }

    public async Task<object> SomeOtherLogic(object data)
    {
        /// random logic
        /// ..
        /// ..
        /// ..
        /// ..
        /// More logic
        
        var newProduct = await _productDao.CreateNewProduct(data);
        return newProduct;
    }
}