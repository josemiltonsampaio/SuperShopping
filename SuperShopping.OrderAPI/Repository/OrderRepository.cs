using Microsoft.EntityFrameworkCore;
using SuperShopping.OrderAPI.Data;
using SuperShopping.OrderAPI.Models;

namespace SuperShopping.OrderAPI.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly DbContextOptions<AppDbContext> _context;

    public OrderRepository(DbContextOptions<AppDbContext> context)
    {
        _context = context;
    }

    public async Task<bool> AddOrder(OrderHeader header)
    {
        try
        {
            if (header == null) return false;
            await using var _db = new AppDbContext(_context);
            _db.OrderHeader.Add(header);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {

            throw;
        }

    }

    public async Task UpdateOrderPaymentStatus(long orderHeaderId, bool status)
    {
        await using var _db = new AppDbContext(_context);
        var header = await _db.OrderHeader.FirstOrDefaultAsync(oh => oh.Id == orderHeaderId);
        if (header != null)
        {
            header.PaymentStatus = status;
            await _db.SaveChangesAsync();
        }
    }
}
