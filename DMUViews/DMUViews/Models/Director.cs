﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMUViews.Models
{
    public class Director
    {
        [Key]
        public int DirectorId { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "You must enter the Director's name.")]
        public string DirectorName { get; set; }
        public string Gender { get; set; }
        public string Biography { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Birth")]
        public System.DateTime DateOfBirth { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }

    }
}