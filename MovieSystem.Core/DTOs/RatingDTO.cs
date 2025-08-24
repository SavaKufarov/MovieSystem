using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Core.DTOs
{   
        public class RatingDto
        {
            public int RatingId { get; set; }  
            public int UserId { get; set; }
            public int MovieId { get; set; }

            public int Rating { get; set; } 

            public string? UserName { get; set; }
            public string? MovieTitle { get; set; }
        }  

}
