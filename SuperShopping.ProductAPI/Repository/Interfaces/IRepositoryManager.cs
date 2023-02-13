namespace SuperShopping.ProductAPI.Repository.Interfaces;
public interface IRepositoryManager
{
    IProductRepository Product { get; }
    ICategoryRepository Category { get; }
    Task SaveAsync();
}
