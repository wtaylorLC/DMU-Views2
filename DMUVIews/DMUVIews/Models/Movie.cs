using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMUViews.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [Display(Name = "Movie Title")]
        [Required(ErrorMessage = "You must enter the Movie Title.")]
        public string MovieTitle { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Released")]
        public System.DateTime DateReleased { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
        public virtual ICollection<Director> Directors { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }

    }
}