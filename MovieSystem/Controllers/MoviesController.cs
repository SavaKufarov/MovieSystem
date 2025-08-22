using Microsoft.AspNetCore.Mvc;
using MovieSystem.Core.Models;
using MovieSystem.Services;
using MovieSystem.Services.Services;

namespace MovieSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly MovieService _service;
        public MoviesController(MovieService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var movie = await _service.GetByIdAsync(id);
            return movie == null ? NotFound() : Ok(movie);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Movie movie)
        {
            await _service.AddAsync(movie);
            return CreatedAtAction(nameof(GetById), new { id = movie.MovieId }, movie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Movie movie)
        {
            if (id != movie.MovieId) return BadRequest();
            await _service.UpdateAsync(movie);
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
