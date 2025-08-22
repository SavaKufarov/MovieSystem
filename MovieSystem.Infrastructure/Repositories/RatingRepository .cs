using Microsoft.EntityFrameworkCore;
using MovieSystem.Core.Models;
using MovieSystem.Core.Repositories;
using MovieSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Infrastructure.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly MovieSystemContext _context;
        public RatingRepository(MovieSystemContext context) => _context = context;

        public async Task<Rating?> GetByIdAsync(int id) =>
            await _context.Ratings.Include(r => r.User).Include(r => r.Movie).FirstOrDefaultAsync(r => r.RatingId == id);

        public async Task<IEnumerable<Rating>> GetAllAsync() =>
            await _context.Ratings.Include(r => r.User).Include(r => r.Movie).ToListAsync();

        public async Task<Rating> AddAsync(Rating rating)
        {
            await _context.Ratings.AddAsync(rating);
            await _context.SaveChangesAsync();

            return rating;
        }

        public async Task UpdateAsync(Rating rating)
        {
            _context.Ratings.Update(rating);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Ratings.FindAsync(id);
            if (entity != null)
            {
                _context.Ratings.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Rating>> GetRatingsForMovieAsync(int movieId) =>
            await _context.Ratings.Where(r => r.MovieId == movieId).Include(r => r.User).ToListAsync();

        public async Task<IEnumerable<Rating>> GetRatingsByUserAsync(int userId) =>
            await _context.Ratings.Where(r => r.UserId == userId).Include(r => r.Movie).ToListAsync();
    }
}

