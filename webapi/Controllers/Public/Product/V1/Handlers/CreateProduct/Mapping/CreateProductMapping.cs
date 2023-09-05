using webapi.Controllers.Public.Product.V1.Handlers.CreateProduct.Response;

namespace webapi.Controllers.Public.Product.V1.Handlers.CreateProduct.Mapping;

//TODO: Discuss automapper vs manual mapping
public static class CreateProductMapping
{
    public static CreateProductResponse Map(object data) => data as CreateProductResponse;
}