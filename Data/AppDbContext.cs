using bootstrap_project.Models;
using Microsoft.EntityFrameworkCore;

namespace bootstrap_project.Data
{
    public class AppDbContext : DbContext
    {
        // DbSet для Orders и Products
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        // Конструктор, принимающий параметры DbContextOptions
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Настройка модели при необходимости
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настройка сущностей, если это необходимо
            base.OnModelCreating(modelBuilder);
        }
    }
}


