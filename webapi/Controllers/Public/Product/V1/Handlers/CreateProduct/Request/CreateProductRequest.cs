namespace webapi.Controllers.Public.Product.V1.Handlers.CreateProduct.Request;


/// <summary>
/// Validated in API layer by either DataAnnotations or fluent validation
/// TODO: Talk about validation
/// </summary>
public class CreateProductRequest
{
    public string SomeProp { get; set; }
}