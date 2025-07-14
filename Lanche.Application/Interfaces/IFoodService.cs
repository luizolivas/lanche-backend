using Lanche.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanche.Application.Interfaces
{
    public interface IFoodService
    {
        Task<IEnumerable<FoodDto>> GetAllAsync();
        Task<FoodDto?> GetByIdAsync(int id);
        Task AddAsync(CreateFoodDTO dto);
        Task UpdateAsync(FoodDto dto);
        Task DeleteAsync(int id);
    }

    public interface IFoodClientService 
    {
        Task<IEnumerable<FoodDto>> GetAllActiveAsync();
        Task<FoodDto?> GetByIdIfActiveAsync(int id);
    }
}
