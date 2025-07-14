using Lanche.Application.Interfaces;
using Lanche.Domain.Entities;
using Lanche.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanche.Application.Services
{
    public class CustomizationOptionService : ICustomizationOptionService, ICustomizationOptionClientService
    {
        private readonly ICustomizationOptionRepository _repository;
        private readonly IFoodCustomizationOptionRepository _foodCustomizationOptionRepository;

        public CustomizationOptionService(ICustomizationOptionRepository repository, IFoodCustomizationOptionRepository foodCustomizationOptionRepository)
        {
            _repository = repository;
            _foodCustomizationOptionRepository = foodCustomizationOptionRepository;
        }

        // Admin: todos, incluindo inativos
        public async Task<IEnumerable<CustomizationOptionDTO>> GetByFoodIdAsync(int foodId, bool includeInactive = false)
        {
            var options = await _foodCustomizationOptionRepository.GetByFoodIdAsync(foodId, includeInactive);

            // Map para DTO
            return options.Select(o => new CustomizationOptionDTO {
                Id = o.Id,
                Name = o.Name,
                IsActive = o.IsActive
            });
        }

        // Cliente: só ativos, delega ao método acima
        public Task<IEnumerable<CustomizationOptionDTO>> GetByFoodIdAsync(int foodId)
            => GetByFoodIdAsync(foodId, false);

        public async Task<CustomizationOptionDTO> CreateAsync(CreateCustomizationOptionDTO dto)
        {
            var entity = new CustomizationOption {
                Name = dto.Name,
                IsActive = dto.IsActive,
            };

            await _repository.AddAsync(entity);

            return new CustomizationOptionDTO {
                Id = entity.Id,
                Name = entity.Name,
                IsActive = dto.IsActive,
            };
        }

        public async Task UpdateAsync(int id, CreateCustomizationOptionDTO dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new Exception("Not found");

            entity.Name = dto.Name;
            await _repository.UpdateAsync(entity);
        }

    }
}
