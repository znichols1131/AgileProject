using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AgileProject.Models
{
    public class Movie : Content
    {
        [Range(0.0d, 1260.0, ErrorMessage = "Error: Movie length must be between 0 and 1260 minutes. The longest film ever recorded was Amra Ekta Cinema Banabo at 1260 minutes.")]
        public int LengthOfMovie { get; set; } // In minutes

        public Movie()
        {
            TypeOfContent = ContentType.Movie;
        }
    }
}