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

        public Task<IEnumerable<User>> GetAllAsync() => _userRepo.GetAllAsync();

        public Task<User> GetByIdAsync(int id) => _userRepo.GetByIdAsync(id);

        public Task CreateAsync(User user) => _userRepo.AddAsync(user);

        public Task UpdateAsync(User user) => _userRepo.UpdateAsync(user);

        public Task DeleteAsync(int id) => _userRepo.DeleteAsync(id);
    }
}
