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
}
