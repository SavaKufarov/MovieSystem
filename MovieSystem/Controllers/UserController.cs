using Microsoft.AspNetCore.Mvc;
using MovieSystem.Core.Models;
using MovieSystem.Services.Services;

namespace MovieSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _userService.GetAllUsersAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) =>
            Ok(await _userService.GetUserByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            await _userService.CreateUserAsync(user);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(User user)
        {
            await _userService.UpdateUserAsync(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok();
        }
    }
}
