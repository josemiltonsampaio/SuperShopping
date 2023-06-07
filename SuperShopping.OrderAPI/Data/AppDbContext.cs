using Microsoft.EntityFrameworkCore;
using SuperShopping.OrderAPI.Models;

namespace SuperShopping.OrderAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
    {

    }

    public DbSet<OrderHeader> OrderHeader { get; set; }
    public DbSet<OrderItem> OrderItem { get; set; }
}
