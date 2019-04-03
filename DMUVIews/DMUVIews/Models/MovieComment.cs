using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMUViews.Models
{
    public class MovieComment
    {
        [Key]
        public int MovieCommentId { get; set; }
        public int MovieId { get; set; }
        public string UserId { get; set; }
        public string Comment { get; set; }
        [Range(1, 10)]
        public float Rating { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Comment Date")]
        public System.DateTime CommentDate { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}