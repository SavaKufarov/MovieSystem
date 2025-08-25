using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieSystem.Core.DTOs;
using MovieSystem.Core.Models;
using MovieSystem.Services.Services;

namespace MovieSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingController : ControllerBase
    {
        private readonly RatingService _ratingService;
        private readonly IMapper _mapper;

        public RatingController(RatingService ratingService, IMapper mapper)
        {
            _ratingService = ratingService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RatingDto>>> GetAll()
        {
            var ratings = await _ratingService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<RatingDto>>(ratings));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RatingDto>> GetById(int id)
        {
            var rating = await _ratingService.GetByIdAsync(id);
            if (rating == null) return NotFound();
            return Ok(_mapper.Map<RatingDto>(rating));
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateRatingDto dto)
        {
            var rating = _mapper.Map<Rating>(dto);
            await _ratingService.AddAsync(rating);
            return CreatedAtAction(nameof(GetById), new { id = rating.RatingId }, _mapper.Map<RatingDto>(rating));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, RatingDto dto)
        {
            if (id != dto.RatingId) return BadRequest();
            var rating = _mapper.Map<Rating>(dto);
            await _ratingService.UpdateAsync(rating);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _ratingService.DeleteAsync(id);
            return NoContent();
        }
    }
}
