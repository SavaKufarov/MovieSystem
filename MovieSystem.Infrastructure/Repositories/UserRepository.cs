using Microsoft.EntityFrameworkCore;
using MovieSystem.Core.Models;
using MovieSystem.Core.Repositories;
using MovieSystem.Infrastructure.Data;

namespace MovieSystem.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MovieSystemContext _context;

        public UserRepository(MovieSystemContext context)
        {
            _context = context;
        }

        public async Task<User> GetByIdAsync(int id) =>
            await _context.Users.FindAsync(id);

        public async Task<IEnumerable<User>> GetAllAsync() =>
            await _context.Users.ToListAsync();

        public async Task<User> AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
