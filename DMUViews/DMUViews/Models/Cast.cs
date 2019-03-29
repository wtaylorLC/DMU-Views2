using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMUVIews.Models
{
    public class Cast
    {
        [Key]
        public virtual int MovieId { get; set; }
        public virtual int ActorId { get; set; }
        public virtual Boolean Star { get; set; }
        public virtual string Role { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Actor Actor { get; set; }
    }
}