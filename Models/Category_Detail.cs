﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Electronics_Items_Management.Models
{
    public class Category_Detail
    {
        public int Id { get; set; }

        [Required]
        public string Product { get; set; }  

        public string Category_Type { get; set; }

    }
}
