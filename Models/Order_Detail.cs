﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Electronics_Items_Management.Models
{
    public class Order_Detail
    {

        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }

        public decimal  Discount { get; set; }

        public decimal Actual_Price { get; set; } 

        //code to connect the customer class with order class
        public int Customer_DetailId { get; set; }
        public Customer_Detail Customer_Detail { get; set; }

        //code to connect the product class with order class
        public int Product_DetailId { get; set; }
        public Product_Detail Product_Detail { get; set; }
    }
}
