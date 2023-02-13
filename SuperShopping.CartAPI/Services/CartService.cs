using AutoMapper;
using SuperShopping.CartAPI.DTO;
using SuperShopping.CartAPI.Models;
using SuperShopping.CartAPI.Repository.Interfaces;
using SuperShopping.CartAPI.Services.Interfaces;

namespace SuperShopping.CartAPI.Services;
public class CartService : ICartService
{
    private readonly IRepositoryManager _repositoryManager;
    public IMapper _mapper;

    public CartService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }


    public async Task ClearCartAsync(int userId)
    {
        await _repositoryManager.CartRepository.ClearCartAsync(userId);
    }

    public async Task<CartDTO> GetCartByUserIdAsync(int userId, bool trackChanges)
    {
        var cart = await _repositoryManager.CartRepository.GetCartByUserIdAsync(userId, trackChanges);
        return _mapper.Map<CartDTO>(cart);
    }

    public async Task RemoveItemFromCartAsync(int cartItemId)
    {
        await _repositoryManager.CartRepository.RemoveFromCartAsync(cartItemId);
    }

    public async Task<CartDTO> SaveOrUpdateCartAsync(CartCreationDTO cart)
    {
        var newCart = _mapper.Map<CartHeader>(cart);
        var savedCart = await _repositoryManager.CartRepository.SaveOrUpdateCartAsync(newCart);

        return _mapper.Map<CartDTO>(savedCart);
    }
}
