using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSystem.Core.Models;

namespace MovieSystem.Core.Repositories
{
    public interface IDirectorRepository
    {
        Task<Director> GetByIdAsync(int id);
        Task<IEnumerable<Director>> GetAllAsync();
        Task<Director> AddAsync(Director director);
        Task UpdateAsync(Director director);
        Task DeleteAsync(int id);
    }
}
