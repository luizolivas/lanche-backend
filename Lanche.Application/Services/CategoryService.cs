using Lanche.Application.DTOs;
using Lanche.Application.Interfaces;
using Lanche.Domain.Entities;
using Lanche.Domain.Interfaces;
using Lanche.Domain.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanche.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task AddAsync(CategoryDto dto)
        {
            var cat = new Category {
                Nome = dto.nome
            };

            await _categoryRepository.AddAsync(cat);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return categories.Select(c => new CategoryDto {
                Id = c.Id,
                nome = c.Nome,
            }).ToList();
        }

        public Task<CategoryDto?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CategoryDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
