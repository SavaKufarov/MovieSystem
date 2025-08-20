using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Core.Models
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        [Range(1, 5)]
        public int RatingScore { get; set; }

        public Rating(int ratingId, int ratingScore)
        {
            
        }
    }
}
