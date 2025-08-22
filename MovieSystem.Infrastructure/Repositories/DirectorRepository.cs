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
    public class DirectorRepository : IDirectorRepository
    {
        private readonly MovieSystemContext _context;
        public DirectorRepository(MovieSystemContext context) => _context = context;

        public async Task<Director?> GetByIdAsync(int id) =>
            await _context.Directors.Include(d => d.Movies).FirstOrDefaultAsync(d => d.DirectorId == id);

        public async Task<IEnumerable<Director>> GetAllAsync() =>
            await _context.Directors.Include(d => d.Movies).ToListAsync();

        public async Task<Director> AddAsync(Director director)
        {
            await _context.Directors.AddAsync(director);
            await _context.SaveChangesAsync();

            return director;
        }

        public async Task UpdateAsync(Director director)
        {
            _context.Directors.Update(director);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Directors.FindAsync(id);
            if (entity != null)
            {
                _context.Directors.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
