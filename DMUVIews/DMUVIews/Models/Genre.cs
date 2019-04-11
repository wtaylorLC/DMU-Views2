using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMUViews.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        [Display(Name = "Genre Name")]
        public string GenreName { get; set; }
        public Boolean IsActive { get; set; }
        public Boolean IsDelete { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }

    }
}