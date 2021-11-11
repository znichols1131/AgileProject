using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileProject.Models
{
    public abstract class Content
    {
        [Key]
        public int ContentId { get; set; }

        [Required, MaxLength(240, ErrorMessage = "Error: Title must be 240 characters or less.")]
        public string Title { get; set; }


        [Required, MaxLength(240, ErrorMessage = "Error: Description must be 240 characters or less.")]
        public string Description { get; set; }

        //[Required]
        public ContentType TypeOfContent { get; set; }

        public virtual List<Rating> Ratings { get; set; } = new List<Rating>();


        // Methods
        public double GetAverageRating()
        {
            double sum = 0.0d;

            if (Ratings.Count == 0)
                return sum;

            foreach (Rating r in Ratings)
            {
                sum += r.Score;
            }

            return sum / Ratings.Count;
        }
    }

    public enum ContentType
    {
        Unknown = 0,
        Movie = 1,
        Show = 2
    }
}
