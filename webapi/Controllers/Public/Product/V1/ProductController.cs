using Microsoft.AspNetCore.Mvc;
using webapi.Controllers.Public.Product.V1.Handlers.CreateProduct;
using webapi.Controllers.Public.Product.V1.Handlers.CreateProduct.Request;
using webapi.Controllers.Public.Product.V1.Handlers.CreateProduct.Response;

namespace webapi.Controllers.Public.Product.V1;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType( StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult> Get([FromServices] CreateProductHandler handler, CreateProductRequest request)
    {
        
        //TODO: Should we map from HTTP request model to som internal model?
        var res = await handler.Execute(request);

        switch (res.Item2)
        {
            case CreateProductHandlerResult.success:
                return Ok(res.Item1);
            case CreateProductHandlerResult.misconfigured:
                return BadRequest();
            case CreateProductHandlerResult.someOtherResult:
                return Conflict();
            default:
                throw new ArgumentOutOfRangeException(); //TODO: configure global exception handling to not expose data
        }
    }
}