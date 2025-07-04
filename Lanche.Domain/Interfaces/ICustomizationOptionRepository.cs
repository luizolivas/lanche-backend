using Lanche.Domain.Entities;
using Lanche.Domain.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanche.Domain.Interfaces
{
    public interface ICustomizationOptionRepository
    {
        Task<IEnumerable<CustomizationOption>> GetAllAsync();
        Task<CustomizationOption?> GetByIdAsync(int id);
        Task AddAsync(CustomizationOption customizationOption);
        Task UpdateAsync(CustomizationOption customizationOption);
        Task DeleteAsync(int id);
    }
}
