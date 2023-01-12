namespace SuperShopping.ProductAPI.Repository;
public interface IRepositoryManager
{
    IProductRepository Product { get; }
    void SaveAsync();
}
