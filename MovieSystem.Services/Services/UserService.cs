using MovieSystem.Core.Models;
using MovieSystem.Core.Repositories;

namespace MovieSystem.Services.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }

        public Task<IEnumerable<User>> GetAllUsersAsync() => _userRepo.GetAllAsync();

        public Task<User> GetUserByIdAsync(int id) => _userRepo.GetByIdAsync(id);

        public Task CreateUserAsync(User user) => _userRepo.AddAsync(user);

        public Task UpdateUserAsync(User user) => _userRepo.UpdateAsync(user);

        public Task DeleteUserAsync(int id) => _userRepo.DeleteAsync(id);
    }
}
