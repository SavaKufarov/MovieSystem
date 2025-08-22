using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieSystem.Core.Models;
using MovieSystem.Core.Repositories;
using MovieSystem.Infrastructure.Data;

namespace MovieSystem.Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieSystemContext _context;
        public MovieRepository(MovieSystemContext context) => _context = context;

        public async Task<Movie?> GetByIdAsync(int id) =>
            await _context.Movies.Include(m => m.Director).Include(m => m.Ratings).FirstOrDefaultAsync(m => m.MovieId == id);

        public async Task<IEnumerable<Movie>> GetAllAsync() =>
            await _context.Movies.Include(m => m.Director).Include(m => m.Ratings).ToListAsync();

        public async Task<Movie> AddAsync(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        public async Task UpdateAsync(Movie movie)
        {
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Movies.FindAsync(id);
            if (entity != null)
            {
                _context.Movies.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
