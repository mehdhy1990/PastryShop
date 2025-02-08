using Microsoft.EntityFrameworkCore;

namespace PastryShop.Models;

public class PastryShopDbContext : DbContext
{
    public PastryShopDbContext(DbContextOptions<PastryShopDbContext> options) : base(options)
    {
    }

    public DbSet<Pie> Pies { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ShoppingCartItems> ShoppingCartItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
}