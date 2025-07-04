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
        public DbSet<CustomizationOption> CustomizationOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração para o relacionamento muitos para muitos entre Food e CustomizationOption
            // O EF Core infere isso, mas explicitá-lo pode ser útil.
            modelBuilder.Entity<Food>()
                .HasMany(f => f.CustomizationOptions) // Um Food tem muitas CustomizationOptions
                .WithMany(co => co.Products);     // E uma CustomizationOption está em muitos Products (Foods)


            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Nome = "Lanches pequenos" },
                new Category { Id = 2, Nome = "Lanches menores" },
                new Category { Id = 3, Nome = "Hambúrgueres" },
                new Category { Id = 4, Nome = "Lanches especiais" },
                new Category { Id = 5, Nome = "Enormes" },
                new Category { Id = 6, Nome = "Lanches de frango" },
                new Category { Id = 7, Nome = "Porções" },
                new Category { Id = 8, Nome = "Sobremesas" },
                new Category { Id = 9, Nome = "Bebidas" }
            );

            modelBuilder.Entity<CustomizationOption>().HasData(
                new CustomizationOption { Id = 1, Name = "Cheddar", Price = 4 },
                new CustomizationOption { Id = 2, Name = "Fatia de Presunto", Price = 2.5m },
                new CustomizationOption { Id = 3, Name = "Barbecue", Price = 5 }
            );

            modelBuilder.Entity<Food>().HasData(
                // Lanches pequenos
                new Food { Id = 1, Name = "Mini X-Burguer", Description = "Pão, carne e queijo", Price = 10.00M, ImageUrl = "https://images.unsplash.com/photo-1601924928584-c6ea3b9d88fd", CategoryId = 1 },
                new Food { Id = 2, Name = "Pão na chapa", Description = "Pão na chapa com manteiga", Price = 6.50M, ImageUrl = "https://images.unsplash.com/photo-1603052879434-9bd7f4589f8f", CategoryId = 1 },
                new Food { Id = 3, Name = "Mini Dog", Description = "Cachorro quente pequeno", Price = 9.00M, ImageUrl = "https://images.unsplash.com/photo-1550547660-d9450f859349", CategoryId = 1 },
                new Food { Id = 4, Name = "Tostex", Description = "Lanche prensado com queijo e presunto", Price = 7.50M, ImageUrl = "https://images.unsplash.com/photo-1605478571440-9b4b27c6c20f", CategoryId = 1 },
                new Food { Id = 5, Name = "Pão com ovo", Description = "Simples e gostoso", Price = 8.00M, ImageUrl = "https://images.unsplash.com/photo-1612197526787-6ce6b33ed654", CategoryId = 1 },

                // Lanches menores
                new Food { Id = 6, Name = "Pão com queijo", Description = "Lanche leve e prático", Price = 7.00M, ImageUrl = "https://images.unsplash.com/photo-1603052879434-9bd7f4589f8f", CategoryId = 2 },
                new Food { Id = 7, Name = "Sanduíche natural", Description = "Com peito de peru e alface", Price = 9.50M, ImageUrl = "https://images.unsplash.com/photo-1523986371872-9d3ba2e2f642", CategoryId = 2 },
                new Food { Id = 8, Name = "Mini misto quente", Description = "Presunto e queijo derretido", Price = 8.50M, ImageUrl = "https://images.unsplash.com/photo-1543772300-69f78b929b14", CategoryId = 2 },
                new Food { Id = 9, Name = "Mini hambúrguer vegetariano", Description = "Hambúrguer pequeno sem carne", Price = 10.00M, ImageUrl = "https://images.unsplash.com/photo-1585238341986-9c7472fd43e1", CategoryId = 2 },
                new Food { Id = 10, Name = "Mini pão com carne louca", Description = "Tradicional e saboroso", Price = 9.90M, ImageUrl = "https://images.unsplash.com/photo-1568605114967-8130f3a36994", CategoryId = 2 },

                // Hambúrgueres
                new Food { Id = 11, Name = "X-Salada", Description = "Hambúrguer com salada", Price = 16.50M, ImageUrl = "https://images.unsplash.com/photo-1550547660-d9450f859349", CategoryId = 3 },
                new Food { Id = 12, Name = "X-Bacon", Description = "Hambúrguer com bacon", Price = 18.00M, ImageUrl = "https://images.unsplash.com/photo-1606755962876-4003c81b8c78", CategoryId = 3 },
                new Food { Id = 13, Name = "X-Egg", Description = "Com ovo frito e queijo", Price = 17.50M, ImageUrl = "https://images.unsplash.com/photo-1612197526787-6ce6b33ed654", CategoryId = 3 },
                new Food { Id = 14, Name = "X-Picanha", Description = "Picanha grelhada no pão", Price = 21.90M, ImageUrl = "https://images.unsplash.com/photo-1606755962876-4003c81b8c78", CategoryId = 3 },
                new Food { Id = 15, Name = "Smash Burger", Description = "Duas carnes prensadas", Price = 22.00M, ImageUrl = "https://images.unsplash.com/photo-1606755962876-4003c81b8c78", CategoryId = 3 },

                // Lanches especiais
                new Food { Id = 16, Name = "X-Tudo", Description = "Hambúrguer completo", Price = 25.00M, ImageUrl = "https://images.unsplash.com/photo-1571091718767-18b5b1457add", CategoryId = 4 },
                new Food { Id = 17, Name = "X-Coração", Description = "Com coração de frango", Price = 24.00M, ImageUrl = "https://images.unsplash.com/photo-1579613832126-b3a5ecf9172b", CategoryId = 4 },
                new Food { Id = 18, Name = "X-Calabresa", Description = "Hambúrguer com calabresa fatiada", Price = 23.00M, ImageUrl = "https://images.unsplash.com/photo-1571091718767-18b5b1457add", CategoryId = 4 },
                new Food { Id = 19, Name = "X-Brigadeiro", Description = "Lanche doce (curioso!)", Price = 15.00M, ImageUrl = "https://images.unsplash.com/photo-1505253210343-d4fdc7b10e8c", CategoryId = 4 },
                new Food { Id = 20, Name = "X-Tudo Duplo", Description = "Versão maior do X-Tudo", Price = 28.00M, ImageUrl = "https://images.unsplash.com/photo-1606755962778-0b6a2d5cd8b3", CategoryId = 4 },

                // Enormes
                new Food { Id = 21, Name = "Mega X-Tudo", Description = "Tudo em dobro", Price = 30.00M, ImageUrl = "https://images.unsplash.com/photo-1606755962778-0b6a2d5cd8b3", CategoryId = 5 },
                new Food { Id = 22, Name = "X-Gigante", Description = "Serve duas pessoas", Price = 35.00M, ImageUrl = "https://images.unsplash.com/photo-1601924638867-3ec6c254a5ae", CategoryId = 5 },
                new Food { Id = 23, Name = "Triplo X", Description = "Três hambúrgueres", Price = 37.50M, ImageUrl = "https://images.unsplash.com/photo-1571091718767-18b5b1457add", CategoryId = 5 },
                new Food { Id = 24, Name = "Torre de Lanche", Description = "Altura impressionante", Price = 42.00M, ImageUrl = "https://images.unsplash.com/photo-1626171454589-37f78f9b0c3c", CategoryId = 5 },
                new Food { Id = 25, Name = "X-Monstro", Description = "Desafio do restaurante", Price = 50.00M, ImageUrl = "https://images.unsplash.com/photo-1606755962778-0b6a2d5cd8b3", CategoryId = 5 },

                // Lanches de frango
                new Food { Id = 26, Name = "Frango Crispy", Description = "Filé empanado", Price = 18.90M, ImageUrl = "https://images.unsplash.com/photo-1606755962876-4003c81b8c78", CategoryId = 6 },
                new Food { Id = 27, Name = "X-Frango", Description = "Frango grelhado e queijo", Price = 17.50M, ImageUrl = "https://images.unsplash.com/photo-1606755962876-4003c81b8c78", CategoryId = 6 },
                new Food { Id = 28, Name = "X-Frango Catupiry", Description = "Com catupiry original", Price = 19.00M, ImageUrl = "https://images.unsplash.com/photo-1606755962876-4003c81b8c78", CategoryId = 6 },
                new Food { Id = 29, Name = "Chicken Burger", Description = "Sanduíche americano", Price = 20.00M, ImageUrl = "https://images.unsplash.com/photo-1606755962876-4003c81b8c78", CategoryId = 6 },
                new Food { Id = 30, Name = "Frango BBQ", Description = "Frango com molho barbecue", Price = 20.50M, ImageUrl = "https://images.unsplash.com/photo-1606755962876-4003c81b8c78", CategoryId = 6 },

                // Porções
                new Food { Id = 31, Name = "Batata Frita", Description = "Crocante e sequinha", Price = 12.00M, ImageUrl = "https://images.unsplash.com/photo-1579912513272-708c5cfeb5f1", CategoryId = 7 },
                new Food { Id = 32, Name = "Aipim frito", Description = "Mandioca frita na hora", Price = 11.00M, ImageUrl = "https://images.unsplash.com/photo-1606755962778-0b6a2d5cd8b3", CategoryId = 7 },
                new Food { Id = 33, Name = "Anéis de cebola", Description = "Porção de onion rings", Price = 10.00M, ImageUrl = "https://images.unsplash.com/photo-1606755962778-0b6a2d5cd8b3", CategoryId = 7 },
                new Food { Id = 34, Name = "Polenta frita", Description = "Deliciosa e crocante", Price = 11.50M, ImageUrl = "https://images.unsplash.com/photo-1606755962778-0b6a2d5cd8b3", CategoryId = 7 },
                new Food { Id = 35, Name = "Frango à passarinho", Description = "Bem temperado", Price = 19.00M, ImageUrl = "https://images.unsplash.com/photo-1606755962778-0b6a2d5cd8b3", CategoryId = 7 },

                // Sobremesas
                new Food { Id = 36, Name = "Petit Gâteau", Description = "Bolo com sorvete", Price = 14.00M, ImageUrl = "https://images.unsplash.com/photo-1609931262918-65d6d172b2dc", CategoryId = 8 },
                new Food { Id = 37, Name = "Sorvete de creme", Description = "Uma bola deliciosa", Price = 7.00M, ImageUrl = "https://images.unsplash.com/photo-1609931262918-65d6d172b2dc", CategoryId = 8 },
                new Food { Id = 38, Name = "Brownie com calda", Description = "Brownie quente", Price = 12.00M, ImageUrl = "https://images.unsplash.com/photo-1609931262918-65d6d172b2dc", CategoryId = 8 },
                new Food { Id = 39, Name = "Churros recheados", Description = "Doce de leite ou chocolate", Price = 10.00M, ImageUrl = "https://images.unsplash.com/photo-1609931262918-65d6d172b2dc", CategoryId = 8 },
                new Food { Id = 40, Name = "Milkshake", Description = "Chocolate ou morango", Price = 13.00M, ImageUrl = "https://images.unsplash.com/photo-1609931262918-65d6d172b2dc", CategoryId = 8 },

                // Bebidas
                new Food { Id = 41, Name = "Guaraná 350ml", Description = "Bebida gelada", Price = 5.00M, ImageUrl = "https://cdn.awsli.com.br/800x800/298/298064/produto/58265265/924400c3ef.jpg", CategoryId = 9 },
                new Food { Id = 42, Name = "Coca-Cola 600ml", Description = "Refrigerante tradicional", Price = 7.00M, ImageUrl = "https://cdn.awsli.com.br/800x800/298/298064/produto/58265265/924400c3ef.jpg", CategoryId = 9 },
                new Food { Id = 43, Name = "Água mineral", Description = "Sem gás", Price = 3.00M, ImageUrl = "https://cdn.awsli.com.br/800x800/298/298064/produto/58265265/924400c3ef.jpg", CategoryId = 9 },
                new Food { Id = 44, Name = "Suco natural", Description = "Laranja ou limão", Price = 6.00M, ImageUrl = "https://cdn.awsli.com.br/800x800/298/298064/produto/58265265/924400c3ef.jpg", CategoryId = 9 },
                new Food { Id = 45, Name = "Chá gelado", Description = "Limão ou pêssego", Price = 5.50M, ImageUrl = "https://cdn.awsli.com.br/800x800/298/298064/produto/58265265/924400c3ef.jpg", CategoryId = 9 }
            );
        }

    }
}
