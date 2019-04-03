using DMUViews.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMUViews.ViewModel
{
    public class MovieCommentsViewModels: BaseEntity
    {
        [Display(Name = "Movie")]
        public int MovieId { get; set; }
        [Display(Name = "User")]
        public string UserId { get; set; }
        public string Comment { get; set; }
        public float Rating { get; set; }
    }
    public class MovieCommentsListViewModel : BaseEntity
    {
        public string MovieTitle { get; set; }
        public int MovieId { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string Comment { get; set; }
        public string UserReaction { get; set; }

    }
}