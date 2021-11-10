using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AgileProject.Models
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }

        [Required, Range(0.0d, 5.0d, ErrorMessage = "Error: score must be between 0.0 and 5.0")]
        public double Score { get; set; }

        [MaxLength(240, ErrorMessage = "Error: reviews must be 240 characters or less.")]
        public string Review { get; set; }

        [Required]
        public int ContentId { get; set; }

        [ForeignKey("ContentId")]
        public Content Content { get; set; }

        public Guid UserId { get; set; }
    }
}