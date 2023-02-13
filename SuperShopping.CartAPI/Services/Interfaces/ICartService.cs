using SuperShopping.CartAPI.DTO;

namespace SuperShopping.CartAPI.Services.Interfaces;
public interface ICartService
{
    Task<CartDTO> GetCartByUserIdAsync(int userId, bool trackChanges);
    Task<CartDTO> SaveOrUpdateCartAsync(CartCreationDTO cart);
    Task RemoveItemFromCartAsync(int cartItemId);
    Task ClearCartAsync(int userId);

}
