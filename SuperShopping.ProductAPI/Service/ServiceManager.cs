using AutoMapper;
using SuperShopping.ProductAPI.Repository;

namespace SuperShopping.ProductAPI.Service;
public class ServiceManager : IServiceManager
{
    private readonly Lazy<IProductService> productService;
    private readonly Lazy<ICategoryService> categoryService;
    public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
    {
        productService = new Lazy<IProductService>(() => new ProductService(repositoryManager, mapper));
        categoryService = new Lazy<ICategoryService>(() => new CategoryService(repositoryManager, mapper));
    }
    public IProductService Product => productService.Value;
    public ICategoryService Category => categoryService.Value;
}
