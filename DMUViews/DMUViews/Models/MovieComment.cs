using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMUVIews.Models
{
    public class MovieComment
    {
        public int MovieId { get; set; }
        public string UserId { get; set; }
        public string Comment { get; set; }
        public virtual float Rating { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Review Date")]
        public virtual System.DateTime ReviewDate { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}