﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMUViews.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}