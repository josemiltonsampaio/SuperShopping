using AutoMapper;
using SuperShopping.CartAPI.RabbitMQSender;
using SuperShopping.CartAPI.Repository.Interfaces;
using SuperShopping.CartAPI.Services.Interfaces;

namespace SuperShopping.CartAPI.Services;
public class ServiceManager : IServiceManager
{
    private readonly Lazy<IProductService> _productService;
    private readonly Lazy<ICartService> _cartService;

    public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper, IRabbitMQMessageSender rabbitMQMessageSender)
    {
        _productService = new Lazy<IProductService>(() => new ProductService(repositoryManager, mapper));
        _cartService = new Lazy<ICartService>(() => new CartService(repositoryManager, mapper, rabbitMQMessageSender));
    }

    public IProductService ProductService => _productService.Value;

    public ICartService CartService => _cartService.Value;
}
