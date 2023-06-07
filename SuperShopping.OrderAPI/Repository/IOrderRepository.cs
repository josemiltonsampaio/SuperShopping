using SuperShopping.OrderAPI.Models;

namespace SuperShopping.OrderAPI.Repository;

public interface IOrderRepository
{
    Task<bool> AddOrder(OrderHeader header);
    Task UpdateOrderPaymentStatus(long orderHeaderId, bool status);
}
