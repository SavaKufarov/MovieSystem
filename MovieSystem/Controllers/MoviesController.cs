using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieSystem.Core.DTOs;
using MovieSystem.Core.Models;
using MovieSystem.Services;
using MovieSystem.Services.Services;

namespace MovieSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly MovieService _movieService;
        private readonly IMapper _mapper;

        public MovieController(MovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetAll()
        {
            var movies = await _movieService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<MovieDto>>(movies));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetById(int id)
        {
            var movie = await _movieService.GetByIdAsync(id);
            if (movie == null) return NotFound();
            return Ok(_mapper.Map<MovieDto>(movie));
        }

        [HttpPost]
        public async Task<ActionResult> Create(MovieDto dto)
        {
            var movie = _mapper.Map<Movie>(dto);
            await _movieService.AddAsync(movie);
            return CreatedAtAction(nameof(GetById), new { id = movie.MovieId }, _mapper.Map<MovieDto>(movie));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, MovieDto dto)
        {
            if (id != dto.MovieId) return BadRequest();
            var movie = _mapper.Map<Movie>(dto);
            await _movieService.UpdateAsync(movie);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _movieService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("user/{userId}/rated-movies")]
        public async Task<IActionResult> GetMoviesRatedByUser(int userId)
        {
            var result = await _movieService.GetMoviesRatedByUserAsync(userId);
            return Ok(result);
        }

        [HttpGet("director/{directorId}/movies-with-avg-rating")]
        public async Task<IActionResult> GetMoviesByDirectorWithAvgRating(int directorId)
        {
            var result = await _movieService.GetMoviesByDirectorWithAvgRatingAsync(directorId);
            return Ok(result);
        }

        [HttpGet("top-rated/{topN}")]
        public async Task<IActionResult> GetTopRatedMovies(int topN)
        {
            var result = await _movieService.GetTopRatedMoviesAsync(topN);
            return Ok(result);
        }
    }
}
