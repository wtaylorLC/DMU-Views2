using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMUViews.Models
{
    public class Filmography
    {
        [Key]
        public int FilmographyId { get; set; }
        public int MovieId { get; set; }
        public int DirectorId { get; set; }
        public Movie Movie { get; set; }
        public Director Director { get; set; }

    }
}