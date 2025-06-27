using Lanche.Application.DTOs.Admin;
using Lanche.Application.DTOs.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanche.Application.Admin.Interfaces
{
    public interface IFoodService
    {
        Task<IEnumerable<FoodDto>> GetAllAsync();
        Task<FoodDto?> GetByIdAsync(int id);
        Task AddAsync(CreateFoodDTO dto);
        Task UpdateAsync(FoodDto dto);
        Task DeleteAsync(int id);
    }
}
