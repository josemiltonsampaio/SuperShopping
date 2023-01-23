using AutoMapper;
using SuperShopping.ProductAPI.DTO;
using SuperShopping.ProductAPI.Models;
using SuperShopping.ProductAPI.Repository;

namespace SuperShopping.ProductAPI.Service;
public class CategoryService : ICategoryService
{
    private readonly IRepositoryManager repositoryManager;
    private readonly IMapper mapper;

    public CategoryService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        this.repositoryManager = repositoryManager;
        this.mapper = mapper;
    }
    public async Task<CategoryDTO> CreateCategoryAsync(CategoryCreationDTO category)
    {
        var categoryToCreate = mapper.Map<Category>(category);

        repositoryManager.Category.CreateCategory(categoryToCreate);
        await repositoryManager.SaveAsync();
        return mapper.Map<CategoryDTO>(categoryToCreate);
    }

    public Task DeleteCategoryAsync(int categoryId, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync(bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public async Task<CategoryDTO> GetCategoryAsync(int id, bool trackChanges)
    {
        var category = await repositoryManager.Category.GetCategoryAsync(id, trackChanges);
        return mapper.Map<CategoryDTO>(category);
    }

    public Task UpdateCategoryAsync(int categoryId, CategoryUpdateDTO categoryUpdateDTO, bool trackChanges)
    {
        throw new NotImplementedException();
    }
}
