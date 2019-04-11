using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMUViews.Models
{
    public class SubComment
    {
        [Key]
        public int SubCommentId { get; set; }
        public string CommentMessage { get; set; }

        public System.DateTime CommentDate { get; set; }
        public int MovieCommentId { get; set; }
        public string UserId { get; set; }

        public virtual MovieComment MovieComment { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}