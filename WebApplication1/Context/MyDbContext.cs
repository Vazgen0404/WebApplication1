using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApplication1.Models.Orders;
using WebApplication1.Models.Products;
using WebApplication1.Models.Users;

namespace WebApplication1.Context
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }
    }
}
