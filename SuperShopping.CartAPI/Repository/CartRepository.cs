using Microsoft.EntityFrameworkCore;
using SuperShopping.CartAPI.Data;
using SuperShopping.CartAPI.Models;
using SuperShopping.CartAPI.Repository.Interfaces;

namespace SuperShopping.CartAPI.Repository;
public class CartRepository : ICartRepository
{
    private readonly AppDbContext _dbContext;

    public CartRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task ClearCartAsync(int userId)
    {
        var items = await _dbContext.CartItem.Include(ci => ci.CartHeader).Where(ci => ci.CartHeader.UserId == userId).ToListAsync();
        _dbContext.CartItem.RemoveRange(items);
    }

    public async Task<CartHeader> GetCartByUserIdAsync(int userId, bool trackChanges)
    {
        CartHeader cartHeader;

        if (trackChanges)
        {
            cartHeader = await _dbContext.CartHeader.Include(ch => ch.Items).ThenInclude(ci => ci.Product).Where(ch => ch.UserId == userId).FirstOrDefaultAsync();
        }
        cartHeader = await _dbContext.CartHeader.Include(ch => ch.Items).ThenInclude(ci => ci.Product).Where(ch => ch.UserId == userId).AsNoTracking().FirstOrDefaultAsync();

        return cartHeader;

    }

    public async Task RemoveFromCartAsync(int cartItemId)
    {
        var cartItem = await _dbContext.CartItem.Where(ci => ci.Id == cartItemId).FirstOrDefaultAsync();
        var total = await _dbContext.CartItem.Where(ci => ci.CartHeaderId == cartItem.CartHeaderId).CountAsync();

        _dbContext.CartItem.Remove(cartItem);

        if (total == 1)
        {
            var cartToRemove = await _dbContext.CartHeader.Where(ch => ch.Id == cartItem.CartHeaderId).SingleOrDefaultAsync();
            _dbContext.CartHeader.Remove(cartToRemove);
        }

    }

    public async Task<CartHeader> SaveOrUpdateCartAsync(CartHeader cartHeader)
    {
        foreach (var item in cartHeader.Items)
        {
            var productFromDb = await _dbContext.Product.Where(p => p.Id == item.ProductId).SingleOrDefaultAsync();
            if (productFromDb != null)
            {
                item.Product = null;
            }

        }

        var existingCart = await _dbContext.CartHeader.Where(ch => ch.UserId == cartHeader.UserId).FirstOrDefaultAsync();
        if (existingCart == null)
        {
            _dbContext.CartHeader.Add(cartHeader);
            await _dbContext.SaveChangesAsync();
            return cartHeader;
        }

        foreach (var item in cartHeader.Items)
        {

            var existingItem = await _dbContext.CartItem.Include(ci => ci.CartHeader).Where(ci => ci.CartHeader.UserId == cartHeader.UserId && ci.ProductId == item.ProductId).SingleOrDefaultAsync();
            if (existingItem == null)
            {
                if (item.Quantity == 0) continue;

                existingCart.Items.Add(item);
            }
            else
            {
                existingItem.Quantity += item.Quantity;

                if (existingItem.Quantity == 0)
                {
                    await RemoveFromCartAsync(existingItem.Id);
                }
            }
        }


        await _dbContext.SaveChangesAsync();
        return existingCart;

    }
}
