using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSystem.Core.Models;

namespace MovieSystem.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
    }
}
