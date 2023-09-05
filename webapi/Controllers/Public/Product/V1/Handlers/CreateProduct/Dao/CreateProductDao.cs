namespace webapi.Controllers.Public.Product.V1.Handlers.CreateProduct.Dao;

public interface ICreateProductDao
{
    Task<object> GetData(Guid id);

    Task<bool> CreateNewProduct(object data) // whatever needs to be saved in the db
        ;
}

public class CreateProductDao : ICreateProductDao
{
    public async Task<object> GetData(Guid id)
    {
        // retrieve data from DB
        return (await Task.FromResult(null as object))!;
    }

    public async Task<bool> CreateNewProduct(object data) // whatever needs to be saved in the db
    {
        // add data to db
        return await Task.FromResult(true);
    }
}