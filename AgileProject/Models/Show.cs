using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgileProject.Models
{
    public class Show
    {
        [Key]
        public int ShowId { get; set; }
        public string Title { get; set; }
        public int NumberOfSeasons { get; set; }
        public string Description { get; set; }
    }
}