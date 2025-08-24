using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieSystem.Core.DTOs;
using MovieSystem.Core.DTOs.MovieSystem.Core.DTOs;
using MovieSystem.Core.Models;
using MovieSystem.Services.Services;

namespace MovieSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public UserController(UserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var users = await _userService.GetAllAsync(); 
            return Ok(_mapper.Map<IEnumerable<UserDto>>(users));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            await _userService.CreateAsync(user);
            return CreatedAtAction(nameof(GetById), new { id = user.UserId }, _mapper.Map<UserDto>(user));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UserDto dto)
        {
            if (id != dto.UserId) return BadRequest();
            var user = _mapper.Map<User>(dto);
            await _userService.UpdateAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }
    }
}
