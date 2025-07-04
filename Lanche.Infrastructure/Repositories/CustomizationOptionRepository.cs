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
    public class CustomizationOptionRepository : ICustomizationOptionRepository
    {

        private readonly AppDbContext _context;

        public CustomizationOptionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomizationOption>> GetAllAsync()
          => await _context.CustomizationOptions.ToListAsync();

        public async Task<CustomizationOption?> GetByIdAsync(int id)
            => await _context.CustomizationOptions.FindAsync(id);

        public async Task AddAsync(CustomizationOption customizationOption)
        {
            _context.CustomizationOptions.Add(customizationOption);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CustomizationOption customizationOption)
        {
            _context.CustomizationOptions.Update(customizationOption);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var customizationOption = await GetByIdAsync(id);
            if (customizationOption is null) return;
            _context.CustomizationOptions.Remove(customizationOption);
            await _context.SaveChangesAsync();
        }
    }
}
