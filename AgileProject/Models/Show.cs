using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgileProject.Models
{
    public class Show : Content
    {
        public int NumberOfSeasons { get; set; }
        public Show()
        {
            TypeOfContent = ContentType.Show;
        }
    }
}