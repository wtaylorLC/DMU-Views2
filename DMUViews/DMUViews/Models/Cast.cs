using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMUViews.Models
{
    public class Cast
    {
        [Key]
        public int CastId { get; set; }
        public int MovieId { get; set; }
        public int ActorId { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Actor Actor { get; set; }

    }
}