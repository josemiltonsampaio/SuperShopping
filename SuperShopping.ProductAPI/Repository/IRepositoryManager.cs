namespace SuperShopping.ProductAPI.Repository;
public interface IRepositoryManager
{
    IProductRepository Product { get; }
    ICategoryRepository Category { get; }
    Task SaveAsync();
}
