using Lanche.Application.DTOs;
using Lanche.Application.Interfaces;
using Lanche.Domain.Interfaces;
using Lanche.Domain.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanche.Application.Services
{
    public class FoodService : IFoodService, IFoodClientService
    {
        private readonly IFoodRepository _repo;

        public FoodService(IFoodRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<FoodDto>> GetAllAsync()
        {
            var foods = await _repo.GetAllAsync();
            return foods.Select(f => new FoodDto {
                Id = f.Id,
                name = f.Name,
                price = f.Price,
                IsActive = f.IsActive
            });
        }

        public async Task<FoodDto?> GetByIdAsync(int id)
        {
            var food = await _repo.GetByIdAsync(id);
            if (food == null) return null;

            return new FoodDto {
                Id = food.Id,
                name = food.Name,
                price = food.Price,
                IsActive = food.IsActive
            };
        }

        public async Task AddAsync(CreateFoodDTO dto)
        {
            var food = new Food {
                Name = dto.Name,
                Price = dto.Price,
                IsActive = dto.IsActive
            };

            await _repo.AddAsync(food);
        }

        public async Task UpdateAsync(FoodDto dto)
        {
            var food = await _repo.GetByIdAsync(dto.Id);
            if (food == null) throw new Exception("Not found");

            food.Name = dto.name;
            food.Price = dto.price;
            food.IsActive = dto.IsActive;

            await _repo.UpdateAsync(food);
        }

        public async Task DeleteAsync(int id)
        {
            var food = await _repo.GetByIdAsync(id);
            if (food == null) throw new Exception("Not found");

            food.IsActive = false;
            await _repo.UpdateAsync(food);
        }

        // IFoodClientService
        public async Task<IEnumerable<FoodDto>> GetAllActiveAsync()
        {
            var foods = await _repo.GetActiveAsync();
            return foods.Select(f => new FoodDto {
                Id = f.Id,
                name = f.Name,
                price = f.Price,
                IsActive = f.IsActive
            });
        }

        public async Task<FoodDto?> GetByIdIfActiveAsync(int id)
        {
            var food = await _repo.GetByIdAsync(id);
            if (food == null || !food.IsActive) return null;

            return new FoodDto {
                Id = food.Id,
                name = food.Name,
                price = food.Price,
                IsActive = food.IsActive
            };
        }
    }

}
