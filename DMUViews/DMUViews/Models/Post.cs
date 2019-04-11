using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMUViews.Models
{
    public class Post
    {
        [Key]
        public string PostId { get; set; }
        public string Message { get; set; }
        public System.DateTime PostDate { get; set; }

    }
}