using AutoMapper;
using SuperShopping.ProductAPI.Repository;

namespace SuperShopping.ProductAPI.Service;
public class ServiceManager : IServiceManager
{
    private readonly Lazy<IProductService> productService;
    public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
    {
        productService = new Lazy<IProductService>(() => new ProductService(repositoryManager, mapper));
    }
    public IProductService Product => productService.Value;
}
