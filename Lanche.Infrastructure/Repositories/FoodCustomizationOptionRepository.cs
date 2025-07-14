using Lanche.Domain.Entities;
using Lanche.Domain.Interfaces;
using Lanche.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanche.Infrastructure.Repositories
{
    public class FoodCustomizationOptionRepository : IFoodCustomizationOptionRepository
    {
        private readonly AppDbContext _context;

        public FoodCustomizationOptionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomizationOption>> GetByFoodIdAsync(int foodId, bool onlyActive = false)
        {
            var query = _context.FoodCustomizationOptions
                .Where(fco => fco.FoodId == foodId);

            if (onlyActive)
                query = query.Where(fco => fco.CustomizationOption.IsActive);

            return await query
                .Select(fco => fco.CustomizationOption)
                .ToListAsync();
        }

        public async Task<IEnumerable<CustomizationOption>> GetAllByFoodIdAsync(int foodId)
        {
            return await _context.FoodCustomizationOptions
                .Where(fco => fco.FoodId == foodId)
                .Select(fco => fco.CustomizationOption)
                .ToListAsync();
        }

        public async Task<IEnumerable<CustomizationOption>> GetActiveByFoodIdAsync(int foodId)
        {
            return await _context.FoodCustomizationOptions
                .Where(fco => foodId == fco.FoodId && fco.CustomizationOption.IsActive)
                .Select(fco => fco.CustomizationOption)
                .ToListAsync();
        }

        public async Task AddAsync(int foodId, int customizationOptionId)
        {
            var exists = await _context.FoodCustomizationOptions
                .AnyAsync(fco => fco.FoodId == foodId && fco.CustomizationOptionId == customizationOptionId);

            if (!exists)
            {
                _context.FoodCustomizationOptions.Add(new FoodCustomizationOption {
                    FoodId = foodId,
                    CustomizationOptionId = customizationOptionId
                });

                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveAsync(int foodId, int customizationOptionId)
        {
            var entity = await _context.FoodCustomizationOptions
                .FirstOrDefaultAsync(fco => fco.FoodId == foodId && fco.CustomizationOptionId == customizationOptionId);

            if (entity != null)
            {
                _context.FoodCustomizationOptions.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
