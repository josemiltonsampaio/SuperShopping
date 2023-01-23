using SuperShopping.ProductAPI.Data;

namespace SuperShopping.ProductAPI.Repository;
public class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IProductRepository> productRepository;
    private readonly Lazy<ICategoryRepository> categoryRepository;
    private readonly AppDbContext appDbContext;

    public RepositoryManager(AppDbContext appDbContext)
    {
        productRepository = new Lazy<IProductRepository>(() => new ProductRepository(appDbContext));
        categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(appDbContext));
        this.appDbContext = appDbContext;
    }
    public IProductRepository Product => productRepository.Value;
    public ICategoryRepository Category => categoryRepository.Value;

    public async Task SaveAsync()
    {
        await appDbContext.SaveChangesAsync();
    }
}
