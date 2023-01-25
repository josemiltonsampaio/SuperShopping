namespace SuperShopping.ProductAPI.Infrastructure.Exceptions;
public abstract class EntityInUseDeleteException : Exception
{
    public EntityInUseDeleteException(string message) : base(message) { }
}
