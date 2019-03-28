using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMUVIews.Models.Admin
{
    public class Actor
    {
        [Key]
        public virtual int ActorId { get; set; }
        [Display(Name = "Full Name")]
        public virtual string FullName { get; set; }
        public virtual string Gender { get; set; }
        public virtual string Biography { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Birth")]
        public System.DateTime DateOfBirth { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string Country { get; set; }
        public virtual ICollection<Cast> Casts { get; set; }
    }
}