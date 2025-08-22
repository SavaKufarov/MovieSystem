using Microsoft.AspNetCore.Mvc;
using MovieSystem.Core.Models;
using MovieSystem.Services;
using MovieSystem.Services.Services;

namespace MovieSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DirectorsController : ControllerBase
    {
        private readonly DirectorService _service;
        public DirectorsController(DirectorService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var director = await _service.GetByIdAsync(id);
            return director == null ? NotFound() : Ok(director);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Director director)
        {
            await _service.AddAsync(director);
            return CreatedAtAction(nameof(GetById), new { id = director.DirectorId }, director);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Director director)
        {
            if (id != director.DirectorId) return BadRequest();
            await _service.UpdateAsync(director);
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
