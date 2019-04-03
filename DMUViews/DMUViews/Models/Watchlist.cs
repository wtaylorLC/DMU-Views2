using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMUViews.Models
{
    public class WatchList
    {
        [Key]
        public int WatchlistId { get; set; }
        public int MovieId { get; set; }
        public string UserId { get; set; }
        public int Quantity { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}