using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMUVIews.Models
{
    public class Movie
    {
        [Key]
        public virtual int MovieId { get; set; }
        [Display(Name = "Movie Title")]
        public virtual string MovieTitle { get; set; }
        public virtual string Description { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Released")]
        public virtual System.DateTime DateReleased { get; set; }
        public virtual ICollection<Watchlist> WatchLists { get; set; }
        public virtual ICollection<Cast> Casts { get; set; }
        public virtual ICollection<MovieComment> MovieComments { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
        public virtual ICollection<Director> Directors { get; set; }
        public virtual ICollection<Filmography> Filmographies { get; set; }
        public virtual ICollection<MovieFile> MovieFiles { get; set; }
    }
}