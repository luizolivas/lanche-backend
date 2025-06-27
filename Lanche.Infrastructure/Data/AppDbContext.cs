using Lanche.Domain.Entities;
using Lanche.Domain.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanche.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Nome = "Lanches" },
                new Category { Id = 2, Nome = "Bebidas" }
            );

            modelBuilder.Entity<Food>().HasData(
                new Food { Id = 1, Name = "X-Burguer", Description = "Hambúrguer com queijo", Price = 15.99M, ImageUrl = "https://images.unsplash.com/photo-1550547660-d9450f859349", CategoryId = 1 },
                new Food { Id = 2, Name = "Coca-Cola", Description = "Refrigerante gelado", Price = 6.50M, ImageUrl = "https://cdn.awsli.com.br/800x800/298/298064/produto/58265265/924400c3ef.jpg", CategoryId = 2 }
            );
        }

    }
}
