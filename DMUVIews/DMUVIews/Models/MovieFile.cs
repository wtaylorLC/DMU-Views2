using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMUVIews.Models.Admin
{
    public class MovieFile
    {
        public int MovieId { get; set; }
        public string ImagePath { get; set; }
        public string Title { get; set; }

        public virtual Movie Movie { get; set; }
    }
}