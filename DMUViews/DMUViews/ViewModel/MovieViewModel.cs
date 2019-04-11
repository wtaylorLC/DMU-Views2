using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMUViews.ViewModel
{
    public class MovieViewModel
    {
        public int GenreID { get; set; }
        public int ActorID { get; set; }
        public int DirectorID { get; set; }
        public string genreName { get; set; }
        public string actorName { get; set; }
        public string directorName { get; set; }
        public bool Assigned { get; set; }
    }
}