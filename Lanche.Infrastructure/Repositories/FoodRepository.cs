using Lanche.Domain.Entities;
using Lanche.Domain.Interfaces;
using Lanche.Domain.Shared.Entities;
using Lanche.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanche.Infrastructure.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private readonly AppDbContext _context;

        public FoodRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Food>> GetAllAsync()
            => await _context.Foods.ToListAsync();

        public async Task<Food?> GetByIdAsync(int id)
            => await _context.Foods.FindAsync(id);

        public async Task AddAsync(Food food)
        {
            _context.Foods.Add(food);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Food food)
        {
            _context.Foods.Update(food);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var food = await GetByIdAsync(id);
            if (food is null) return;
            _context.Foods.Remove(food);
            await _context.SaveChangesAsync();
        }

        public async Task<Food> GetFoodWithCustomizationsAsync(int id)
        {
            return await _context.Foods
                                 .Include(f => f.CustomizationOptions)
                                 .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task AddCustomizationToFood(int foodId, int customizationId)
        {
            var food = await _context.Foods
                                 .Include(f => f.CustomizationOptions)
                                 .FirstOrDefaultAsync(f => f.Id == foodId);

            var customizationOption = await _context.CustomizationOptions
                                                    .FirstOrDefaultAsync(co => co.Id == customizationId);

            if (food != null && customizationOption != null)
            {
                // Adiciona a opção à coleção do Food.
                // O EF Core vai criar uma nova entrada na tabela de junção.
                food.CustomizationOptions.Add(customizationOption);
                await _context.SaveChangesAsync();
                Console.WriteLine($"Opção '{customizationOption.Name}' adicionada ao '{food.Name}'.");
            }
        }
    }

}
