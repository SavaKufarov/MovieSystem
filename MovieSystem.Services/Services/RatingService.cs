using MovieSystem.Core.Models;
using MovieSystem.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Services.Services
{
    public class RatingService
    {
        private readonly IRatingRepository _ratingRepo;
        public RatingService(IRatingRepository ratingRepo)
        {
            _ratingRepo = ratingRepo;
        }

        public Task<IEnumerable<Rating>> GetAllAsync() => _ratingRepo.GetAllAsync();
        public Task<Rating> GetByIdAsync(int id) => _ratingRepo.GetByIdAsync(id);
        public Task AddAsync(Rating rating) => _ratingRepo.AddAsync(rating);
        public Task UpdateAsync(Rating rating) => _ratingRepo.UpdateAsync(rating);
        public Task DeleteAsync(int id) => _ratingRepo.DeleteAsync(id);

        public Task<IEnumerable<Rating>> GetRatingsForMovieAsync(int movieId) => _ratingRepo.GetRatingsForMovieAsync(movieId);
        public Task<IEnumerable<Rating>> GetRatingsByUserAsync(int userId) => _ratingRepo.GetRatingsByUserAsync(userId);
    }
}
