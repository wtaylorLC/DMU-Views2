using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMUVIews.Models
{
    public class Watchlist
    {
        public int MovieId { get; set; }
        public string UserId { get; set; }
        public int Quantity { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}