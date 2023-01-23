namespace SuperShopping.ProductAPI.Service;
public interface IServiceManager
{
    IProductService Product { get; }
    ICategoryService Category { get; }
}
