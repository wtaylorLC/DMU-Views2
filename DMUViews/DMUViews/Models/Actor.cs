using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMUViews.Models
{
    public class Actor
    {
        public int ActorId { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Biography { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Town { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Boolean Star {get; set;}
    }
}
