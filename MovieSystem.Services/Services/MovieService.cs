using MovieSystem.Core.Models;
using MovieSystem.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Services.Services
{
    public class MovieService
    {
        private readonly IMovieRepository _movieRepo;
        public MovieService(IMovieRepository movieRepo)
        {
            _movieRepo = movieRepo;

        }

        public Task<IEnumerable<Movie>> GetAllAsync() => _movieRepo.GetAllAsync();
        public Task<Movie> GetByIdAsync(int id) => _movieRepo.GetByIdAsync(id);
        public Task AddAsync(Movie movie) => _movieRepo.AddAsync(movie);
        public Task UpdateAsync(Movie movie) => _movieRepo.UpdateAsync(movie);
        public Task DeleteAsync(int id) => _movieRepo.DeleteAsync(id);
    }
}
