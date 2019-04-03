using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMUViews.Models
{
    public class MovieGenres
    {
        [Key]
        public int GenreMoviesId { get; set; }
        public int MovieId { get; set; }
        public int GenreId { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Genre Genre { get; set; }
    }
}