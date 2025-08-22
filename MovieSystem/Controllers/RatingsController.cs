using Microsoft.AspNetCore.Mvc;
using MovieSystem.Core.Models;
using MovieSystem.Services;
using MovieSystem.Services.Services;

namespace MovieSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingsController : ControllerBase
    {
        private readonly RatingService _service;
        public RatingsController(RatingService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var rating = await _service.GetByIdAsync(id);
            return rating == null ? NotFound() : Ok(rating);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Rating rating)
        {
            await _service.AddAsync(rating);
            return CreatedAtAction(nameof(GetById), new { id = rating.RatingId }, rating);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Rating rating)
        {
            if (id != rating.RatingId) return BadRequest();
            await _service.UpdateAsync(rating);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("movie/{movieId}")]
        public async Task<IActionResult> GetRatingsForMovie(int movieId) =>
            Ok(await _service.GetRatingsForMovieAsync(movieId));

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetRatingsByUser(int userId) =>
            Ok(await _service.GetRatingsByUserAsync(userId));
    }
}
