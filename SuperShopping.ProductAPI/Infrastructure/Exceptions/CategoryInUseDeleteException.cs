namespace SuperShopping.ProductAPI.Infrastructure.Exceptions;
public class CategoryInUseDeleteException : EntityInUseDeleteException
{
    public CategoryInUseDeleteException(int categoryId) : base($"The category with id:{categoryId} is in use and cannot be deleted.")
    {
    }
}
