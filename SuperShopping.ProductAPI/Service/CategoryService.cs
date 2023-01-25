using AutoMapper;
using SuperShopping.ProductAPI.DTO;
using SuperShopping.ProductAPI.Infrastructure.Exceptions;
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

    public async Task DeleteCategoryAsync(int categoryId)
    {

        var categoryEntity = await repositoryManager.Category.GetCategoryAsync(categoryId, true);

        if (await repositoryManager.Category.CategoryInUseAsync(categoryId))
        {
            throw new CategoryInUseDeleteException(categoryId);
        }

        repositoryManager.Category.DeleteCategory(categoryEntity);
        await repositoryManager.SaveAsync();


    }

    public async Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync(bool trackChanges)
    {
        return mapper.Map<IList<CategoryDTO>>(await repositoryManager.Category.GetAllCategoriesAsync(trackChanges));
    }

    public async Task<CategoryDTO> GetCategoryAsync(int id, bool trackChanges)
    {
        var category = await repositoryManager.Category.GetCategoryAsync(id, trackChanges);
        return mapper.Map<CategoryDTO>(category);
    }

    public async Task UpdateCategoryAsync(int categoryId, CategoryUpdateDTO categoryUpdateDTO)
    {
        var categoryEntity = await repositoryManager.Category.GetCategoryAsync(categoryId, true);
        if (categoryEntity is null)
        {
            throw new CategoryNotFoundException(categoryId);
        }
        mapper.Map(categoryUpdateDTO, categoryEntity);
        await repositoryManager.SaveAsync();
    }
}
