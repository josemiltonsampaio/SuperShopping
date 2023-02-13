namespace SuperShopping.CartAPI.Repository.Interfaces;
public interface IRepositoryManager
{
    IProductRepository ProductRepository { get; }
    ICartRepository CartRepository { get; }
    Task SaveAsync();
}
