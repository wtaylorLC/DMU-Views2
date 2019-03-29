using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMUVIews.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        [Display(Name = "Genre Name")]
        public string GenreName { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}