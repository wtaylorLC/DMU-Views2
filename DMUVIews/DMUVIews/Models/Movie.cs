using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DMUViews.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [Display(Name = "Movie Title")]
        public string MovieTitle { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Writer { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Released")]
        public System.DateTime DateReleased { get; set; }
        public virtual ICollection<WatchList> WatchLists { get; set; }
        public virtual ICollection<MovieComment> MovieComments { get; set; }
        public virtual ICollection<Cast> Casts { get; set; }
        public virtual ICollection<Filmography> Filmographies { get; set; }
        public virtual ICollection<MovieGenres> Genres { get; set; }
        public IEnumerable<Genre> GenreCollection { set; get; }
        public string[] SelectedIDArray { get; set; }

        public IQueryable<MovieComment> UserReaction { set; get; }
    }
}