namespace SuperShopping.CartAPI.Services.Interfaces;
public interface IServiceManager
{
    IProductService ProductService { get; }
    ICartService CartService { get; }
}
