using MovieSystem.Core.Models;
using MovieSystem.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Services.Services
{
    public class DirectorService
    {
        private readonly IDirectorRepository _directorRepo;
        public DirectorService(IDirectorRepository directorRepo)
        { 
            _directorRepo = directorRepo; 
        }

        public Task<IEnumerable<Director>> GetAllAsync() => _directorRepo.GetAllAsync();
        public Task<Director> GetByIdAsync(int id) => _directorRepo.GetByIdAsync(id);
        public Task AddAsync(Director director) => _directorRepo.AddAsync(director);
        public Task UpdateAsync(Director director) => _directorRepo.UpdateAsync(director);
        public Task DeleteAsync(int id) => _directorRepo.DeleteAsync(id);
    }
}
