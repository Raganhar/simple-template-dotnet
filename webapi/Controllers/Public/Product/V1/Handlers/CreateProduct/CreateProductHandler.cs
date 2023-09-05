using webapi.Controllers.Public.Product.V1.Handlers.CreateProduct.Dao;
using webapi.Controllers.Public.Product.V1.Handlers.CreateProduct.Mapping;
using webapi.Controllers.Public.Product.V1.Handlers.CreateProduct.RandomLogic;
using webapi.Controllers.Public.Product.V1.Handlers.CreateProduct.Request;
using webapi.Controllers.Public.Product.V1.Handlers.CreateProduct.Response;

namespace webapi.Controllers.Public.Product.V1.Handlers.CreateProduct;

public class CreateProductHandler
{
    private ICreateProductDao _productDao;
    private ICreateProductBusinessMagic _businessMagic;

    public CreateProductHandler(ICreateProductDao productDao, ICreateProductBusinessMagic businessMagic)
    {
        _productDao = productDao;
        _businessMagic = businessMagic;
    }

    public async Task<(CreateProductResponse, CreateProductHandlerResult)> Execute(CreateProductRequest request)
    {
        var product = await _productDao.GetData(Guid.Empty);
        if (product is null)
        {
            return (null, CreateProductHandlerResult.someOtherResult);
        }

        if (await _businessMagic.SomeLogic())
        {
            return (null, CreateProductHandlerResult.misconfigured);
        }

        var someOtherLogic = await _businessMagic.SomeOtherLogic(request);

        return (CreateProductMapping.Map(someOtherLogic), CreateProductHandlerResult.success);
    }
}

public enum CreateProductHandlerResult
{
    success,
    misconfigured,
    someOtherResult
}