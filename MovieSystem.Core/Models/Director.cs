using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Core.Models
{
    public class Director
    {
        [Key]
        public int DirectorId { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }

        public List<Movie> Movies { get; set; } = new List<Movie>();

        public Director()
        {
                
        }

        public Director(int directorId, string name) 
        {
            DirectorId = directorId;
            Name = name;
        }
    }
}
