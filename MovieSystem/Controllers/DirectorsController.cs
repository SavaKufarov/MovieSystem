using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieSystem.Core.DTOs;
using MovieSystem.Core.Models;
using MovieSystem.Services.Services;

namespace MovieSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DirectorsController : ControllerBase
    {
        private readonly DirectorService _directorService;
        private readonly IMapper _mapper;

        public DirectorsController(DirectorService directorService, IMapper mapper)
        {
            _directorService = directorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DirectorDto>>> GetAll()
        {
            var directors = await _directorService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<DirectorDto>>(directors));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DirectorDto>> GetById(int id)
        {
            var director = await _directorService.GetByIdAsync(id);
            if (director == null) return NotFound();
            return Ok(_mapper.Map<DirectorDto>(director));
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateDirectorDto dto)
        {
            var director = _mapper.Map<Director>(dto);
            await _directorService.AddAsync(director);
            return CreatedAtAction(nameof(GetById), new { id = director.DirectorId }, _mapper.Map<DirectorDto>(director));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, DirectorDto dto)
        {
            if (id != dto.DirectorId) return BadRequest();
            var director = _mapper.Map<Director>(dto);
            await _directorService.UpdateAsync(director);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _directorService.DeleteAsync(id);
            return NoContent();
        }
    }
}
