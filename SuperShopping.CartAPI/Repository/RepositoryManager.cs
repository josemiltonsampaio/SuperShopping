using SuperShopping.CartAPI.Data;
using SuperShopping.CartAPI.Repository.Interfaces;

namespace SuperShopping.CartAPI.Repository;
public class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IProductRepository> _productRepository;
    private readonly Lazy<ICartRepository> _cartRepository;
    private readonly AppDbContext _appDbContext;

    public RepositoryManager(AppDbContext appDbContext)
    {
        _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(appDbContext));
        _cartRepository = new Lazy<ICartRepository>(() => new CartRepository(appDbContext));
        _appDbContext = appDbContext;
    }
    public IProductRepository ProductRepository => _productRepository.Value;
    public ICartRepository CartRepository => _cartRepository.Value;

    public async Task SaveAsync()
    {
        await _appDbContext.SaveChangesAsync();
    }
}
