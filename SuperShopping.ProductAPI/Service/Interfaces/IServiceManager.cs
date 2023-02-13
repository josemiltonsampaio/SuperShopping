namespace SuperShopping.ProductAPI.Service.Interfaces;
public interface IServiceManager
{
    IProductService Product { get; }
    ICategoryService Category { get; }
}
