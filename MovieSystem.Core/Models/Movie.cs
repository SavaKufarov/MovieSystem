using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Core.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }

        public int DirectorId { get; set; }
        public Director Director { get; set; }

        public List<Rating> Ratings { get; set; } = new List<Rating>();
    }
}
