using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Core.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required, MaxLength(30)]
        public string FirstName { get; set; }

        [Required, MaxLength(30)]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<Rating> Ratings { get; set; } = new List<Rating>();
    }
}
