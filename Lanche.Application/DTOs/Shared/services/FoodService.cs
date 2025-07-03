using Lanche.Application.DTOs.Admin;
using Lanche.Application.DTOs.Shared.DTOs;
using Lanche.Application.DTOs.Shared.services.Interfaces;
using Lanche.Domain.Interfaces;
using Lanche.Domain.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanche.Application.DTOs.Shared.services
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _repo;

        public FoodService(IFoodRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<FoodDto>> GetAllAsync()
        {
            var foods = await _repo.GetAllAsync();
            return foods.Select(f => new FoodDto
            {
                Id = f.Id,
                name = f.Name,
                description = f.Description,
                price = f.Price,
                imageUrl = f.ImageUrl,
                idCategory = f.CategoryId
            });
        }

        public async Task<FoodDto?> GetByIdAsync(int id)
        {
            var food = await _repo.GetByIdAsync(id);
            return food == null ? null : new FoodDto
            {
                Id = food.Id,
                name = food.Name,
                description = food.Description,
                price = food.Price,
                imageUrl = food.ImageUrl
            };
        }

        public async Task AddAsync(CreateFoodDTO dto)
        {
            var food = new Food
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                ImageUrl = dto.ImageUrl
            };
            await _repo.AddAsync(food);
        }

        public async Task UpdateAsync(FoodDto dto)
        {
            var food = new Food
            {
                Id = dto.Id,
                Name = dto.name,
                Description = dto.description,
                Price = dto.price,
                ImageUrl = dto.imageUrl
            };
            await _repo.UpdateAsync(food);
        }

        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);
    }

}
