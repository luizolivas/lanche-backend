using Lanche.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanche.Domain.Interfaces
{
    public interface IFoodCustomizationOptionRepository
    {
        Task<IEnumerable<CustomizationOption>> GetByFoodIdAsync(int foodId, bool onlyActive = false);
        Task AddAsync(int foodId, int customizationOptionId);
        Task RemoveAsync(int foodId, int customizationOptionId);
    }
}
