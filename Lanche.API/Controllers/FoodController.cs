using Lanche.Application.Admin.Interfaces;
using Lanche.Application.DTOs.Admin;
using Lanche.Application.DTOs.Food;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lanche.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _service;

        public FoodController(IFoodService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var food = await _service.GetByIdAsync(id);
            return food is null ? NotFound() : Ok(food);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFoodDTO dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = dto.Name }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, FoodDTO dto)
        {
            if (id != dto.Id) return BadRequest();
            await _service.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
