using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMUViews.Models
{
    public class MoviesViewModel
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Writer { get; set; }
        public string DateReleased { get; set; }
        public List<CheckBoxViewModel> Actors { get; set; }
        public List<CheckBoxViewModel> Directors { get; set; }
        public List<CheckBoxViewModel> Genres { get; set; }
    }
}