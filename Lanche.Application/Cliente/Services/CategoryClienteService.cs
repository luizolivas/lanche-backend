using Lanche.Application.Cliente.Services.Interfaces;
using Lanche.Application.DTOs;
using Lanche.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanche.Application.Cliente.Services
{
    public class CategoryClientService : ICategoryClientService
    {
        private readonly ICategoryRepository _repository;

        public CategoryClientService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var categories = await _repository.GetAllAsync();
            return categories.Select(c => new CategoryDto {
                Id = c.Id,
                nome = c.Nome,
            }).ToList();
        }
    }
}
