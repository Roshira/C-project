using Microsoft.EntityFrameworkCore;
using WebApplication1.Date.Models;

namespace WebApplication1.Date
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options) { }

        public DbSet<Car> Car { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ShopCartItem> shopCartItems { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Конфігурація для OrderDetail
            modelBuilder.Entity<OrderDetail>()
                .HasOne(o => o.Auto)
                .WithMany()
                .HasForeignKey(od => od.CarID);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(o => o.order)
                .WithMany(o => o.orderDetails)
                .HasForeignKey(od => od.orderID);
        }
    }
}