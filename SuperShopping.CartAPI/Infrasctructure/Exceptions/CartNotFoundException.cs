namespace SuperShopping.CartAPI.Infrastructure.Exceptions;
public sealed class CartNotFoundException : NotFoundException
{
    public CartNotFoundException(int userId) : base($"The cart from id user: {userId} doesn't exist in the database.")
    {
    }
}
