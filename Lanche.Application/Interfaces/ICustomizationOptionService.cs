using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanche.Application.Interfaces
{
    public interface ICustomizationOptionService
    {
        Task<IEnumerable<CustomizationOptionDTO>> GetByFoodIdAsync(int foodId, bool includeInactive = false);
        Task<CustomizationOptionDTO> CreateAsync(CreateCustomizationOptionDTO dto);
        Task UpdateAsync(int id, CreateCustomizationOptionDTO dto);
    }

    public interface ICustomizationOptionClientService
    {
        Task<IEnumerable<CustomizationOptionDTO>> GetByFoodIdAsync(int foodId);
    }
}
