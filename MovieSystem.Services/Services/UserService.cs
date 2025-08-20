using MovieSystem.Core.Models;
using MovieSystem.Core.Repositories;

namespace MovieSystem.Services.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<IEnumerable<User>> GetAllUsersAsync() =>
            _userRepository.GetAllAsync();

        public Task<User> GetUserByIdAsync(int id) =>
            _userRepository.GetByIdAsync(id);

        public Task CreateUserAsync(User user) =>
            _userRepository.AddAsync(user);

        public Task UpdateUserAsync(User user) =>
            _userRepository.UpdateAsync(user);

        public Task DeleteUserAsync(int id) =>
            _userRepository.DeleteAsync(id);
    }
}
