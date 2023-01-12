using SuperShopping.ProductAPI.Data;

namespace SuperShopping.ProductAPI.Repository;
public class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IProductRepository> productRepository;
    public RepositoryManager(AppDbContext appDbContext)
    {
        productRepository = new Lazy<IProductRepository>(() => new ProductRepository(appDbContext));
    }
    public IProductRepository Product => productRepository.Value;

    public void SaveAsync()
    {
        throw new NotImplementedException();
    }
}
