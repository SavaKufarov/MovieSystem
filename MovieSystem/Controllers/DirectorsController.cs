using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieSystem.Core.Models;
using MovieSystem.Core.DTOs;
using AutoMapper;
using MovieSystem.Infrastructure.Data;

namespace MovieSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DirectorsController : ControllerBase
    {
        private readonly MovieSystemContext _context;
        private readonly IMapper _mapper;

        public DirectorsController(MovieSystemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DirectorDto>>> GetAll()
        {
            var directors = await _context.Directors.ToListAsync();
            return _mapper.Map<List<DirectorDto>>(directors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DirectorDto>> GetById(int id)
        {
            var director = await _context.Directors.FindAsync(id);
            if (director == null) return NotFound();

            return _mapper.Map<DirectorDto>(director);
        }

        [HttpPost]
        public async Task<ActionResult<DirectorDto>> Create(CreateDirectorDto dto)
        {
            var director = _mapper.Map<Director>(dto);

            _context.Directors.Add(director);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = director.DirectorId }, _mapper.Map<DirectorDto>(director));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateDirectorDto dto)
        {
            var director = await _context.Directors.FindAsync(id);
            if (director == null) return NotFound();

            _mapper.Map(dto, director);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var director = await _context.Directors.FindAsync(id);
            if (director == null) return NotFound();

            _context.Directors.Remove(director);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
