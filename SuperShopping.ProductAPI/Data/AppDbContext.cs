using Microsoft.EntityFrameworkCore;
using SuperShopping.ProductAPI.Models;

namespace SuperShopping.ProductAPI.Data;
public class AppDbContext : DbContext
{
    public DbSet<Category> Category { get; set; }
    public DbSet<Product> Product { get; set; }

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
