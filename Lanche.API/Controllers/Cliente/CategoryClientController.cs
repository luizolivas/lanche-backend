using Lanche.Application.Cliente.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lanche.API.Controllers.Cliente
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryClientController : ControllerBase
    {
        private readonly ICategoryClientService _service;

        public CategoryClientController(ICategoryClientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _service.GetAllAsync();
            return Ok(categories);
        }
    }
}
