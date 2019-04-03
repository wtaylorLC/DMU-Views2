using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMUViews.ViewModel
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string MovieTitle { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string DirectorName { get; set; }
        public string Star { get;  set; }
        public string FullCast { get; set; }
        public string ReleaseDate { get; set; }
        public int NoOfReviews { get; set; }
    }
}