using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSystem.Core.Models;

namespace MovieSystem.Core.Repositories
{
    public interface IMovieRepository
    {
        Task<Movie> GetByIdAsync(int id);
        Task<IEnumerable<Movie>> GetAllAsync();
        Task AddAsync(Movie movie);
        Task UpdateAsync(Movie movie);
        Task DeleteAsync(int id);
    }
}
