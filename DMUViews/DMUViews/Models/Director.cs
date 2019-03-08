using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMUViews.Models
{
    public class Director
    {
        public int DirectorId { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Biography { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Town { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
