using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SuperShopping.AuthAPI.Models;

namespace SuperShopping.AuthAPI.Data;
public class AppDbContext : IdentityDbContext<User, IdentityRole<int>, int>
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IdentityRole<int>>().HasData(
            new IdentityRole<int> { Id = 1, ConcurrencyStamp = Guid.NewGuid().ToString(), Name = "admin", NormalizedName = "ADMIN" }
            );

        builder.Entity<IdentityRole<int>>().HasData(
            new IdentityRole<int> { Id = 2, ConcurrencyStamp = Guid.NewGuid().ToString(), Name = "user", NormalizedName = "USER" }
            );

        var adminUser = new User()
        {
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            Email = "admin@admin.com",
            NormalizedEmail = "ADMIN@ADMIN.COM",
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString(),
            Id = 1
        };

        var hasher = new PasswordHasher<User>();
        adminUser.PasswordHash = hasher.HashPassword(adminUser, "Senha123!");
        builder.Entity<User>().HasData(adminUser);

        builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { UserId = 1, RoleId = 1 });
    }
}
