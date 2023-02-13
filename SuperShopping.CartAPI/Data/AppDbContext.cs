using Microsoft.EntityFrameworkCore;
using SuperShopping.CartAPI.Models;

namespace SuperShopping.CartAPI.Data;
public class AppDbContext : DbContext
{
    public DbSet<Product> Product { get; set; }
    public DbSet<CartHeader> CartHeader { get; set; }
    public DbSet<CartItem> CartItem { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("money");

        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
