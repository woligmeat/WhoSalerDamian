using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WhoSalerDamian.Entities;

namespace WhoSalerDamian.Database
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<ShopEntity> Shops { get; set; }
        public DbSet<WholesalersEntity> Wholesalers { get; set; }
        public AppDbContext(DbContextOptions options) : base(options) {}
    }
}