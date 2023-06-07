using AutoMapper;
using SuperShopping.CartAPI.DTO;
using SuperShopping.CartAPI.Infrastructure.Exceptions;
using SuperShopping.CartAPI.Models;
using SuperShopping.CartAPI.RabbitMQSender;
using SuperShopping.CartAPI.Repository.Interfaces;
using SuperShopping.CartAPI.Services.Interfaces;

namespace SuperShopping.CartAPI.Services;
public class CartService : ICartService
{
    private readonly IRepositoryManager _repositoryManager;
    public IMapper _mapper;
    private IRabbitMQMessageSender _rabbitMQMessageSender;

    public CartService(IRepositoryManager repositoryManager, IMapper mapper, IRabbitMQMessageSender rabbitMQMessageSender)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
        _rabbitMQMessageSender = rabbitMQMessageSender;
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
        await _repositoryManager.SaveAsync();
    }

    public async Task<CartDTO> SaveOrUpdateCartAsync(CartCreationDTO cart)
    {
        var newCart = _mapper.Map<CartHeader>(cart);
        var savedCart = await _repositoryManager.CartRepository.SaveOrUpdateCartAsync(newCart);

        return _mapper.Map<CartDTO>(savedCart);
    }

    public async Task Checkout(CheckoutCreationDTO checkoutCreation)
    {
        var checkout = _mapper.Map<CheckoutDTO>(checkoutCreation);
        var cart = await _repositoryManager.CartRepository.GetCartByUserIdAsync(checkout.UserId, false);
        if (cart == null)
        {
            throw new CartNotFoundException(checkout.UserId);
        }

        checkout.Cart = _mapper.Map<CartDTO>(cart);
        checkout.DateTime = DateTime.UtcNow;

        //TODO: Send to RabbitMQ
        _rabbitMQMessageSender.SendMessage(checkout, "checkoutqueue");
        //TODO: Clear the cart

    }
}
