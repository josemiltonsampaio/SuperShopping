using SuperShopping.CartAPI.Models;

namespace SuperShopping.CartAPI.Repository.Interfaces;
public interface ICartRepository
{
    Task<CartHeader> GetCartByUserIdAsync(int userId, bool trackChanges);
    Task<CartHeader> SaveOrUpdateCartAsync(CartHeader cartHeader);
    Task RemoveFromCartAsync(int cartItemId);
    Task ClearCartAsync(int userId);
}
