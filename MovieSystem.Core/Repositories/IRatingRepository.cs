using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSystem.Core.Models;

namespace MovieSystem.Core.Repositories
{
    public interface IRatingRepository
    {
        Task<Rating?> GetByIdAsync(int id);
        Task<IEnumerable<Rating>> GetAllAsync();
        Task AddAsync(Rating rating);
        Task UpdateAsync(Rating rating);
        Task DeleteAsync(int id);

        Task<IEnumerable<Rating>> GetRatingsForMovieAsync(int movieId);

        Task<IEnumerable<Rating>> GetRatingsByUserAsync(int userId);
    }
}
