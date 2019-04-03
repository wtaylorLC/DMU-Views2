﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMUViews.Models
{
    public class Actor
    {
        [Key]
        public  int ActorId { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Biography { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Birth")]
        public System.DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public virtual ICollection<Cast> Casts { get; set; }
    }
}