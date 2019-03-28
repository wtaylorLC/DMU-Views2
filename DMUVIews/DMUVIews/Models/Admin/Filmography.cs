using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMUVIews.Models.Admin
{
    public class Filmography
    {
        [Key]
        public virtual int FilmographyId { get; set; }
        public virtual int MovieId { get; set; }
        public virtual int DirectorId { get; set; }
        public virtual Boolean Writer { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Director Director { get; set; }
       
    }
}