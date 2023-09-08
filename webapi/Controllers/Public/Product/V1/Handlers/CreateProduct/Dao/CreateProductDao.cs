namespace webapi.Controllers.Public.Product.V1.Handlers.CreateProduct.Dao;

public interface ICreateProductDao
{
    Task<object> GetData(Guid id);

    Task<bool> CreateNewProduct(object data); // whatever needs to be saved in the db
    
}
//TODO reflect no DAO classes vs C2B & Managed commands
public class CreateProductDao : ICreateProductDao
{
    //dbcontext
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