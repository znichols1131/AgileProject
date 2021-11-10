using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AgileProject.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        
        [Required, MaxLength(240, ErrorMessage = "Error: Movie title must be 240 characters or less.")]
        public string Title { get; set; }

        [Required, MaxLength(240, ErrorMessage = "Error: Movie description must be 240 characters or less")]
        public string Description { get; set; }

        //[ForeignKey("RatingId")]
        public virtual List<Rating> Ratings { get; set; } = new List<Rating>();

        public double GetAverageRating()
        {
            double sum = 0.0d;

            if (Ratings.Count == 0)
                return sum;

            foreach(Rating r in Ratings)
            {
                sum += r.Score;
            }

            return sum / Ratings.Count;
        }
    }
}