using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Electronics_Items_Management.Models;

namespace Electronics_Items_Management.Data
{
    public class ElectronicDatabase : DbContext
    {
        public ElectronicDatabase (DbContextOptions<ElectronicDatabase> options)
            : base(options)
        {
        }

        public DbSet<Electronics_Items_Management.Models.Brand_Detail> Brand_Detail { get; set; }

        public DbSet<Electronics_Items_Management.Models.Category_Detail> Category_Detail { get; set; }

        public DbSet<Electronics_Items_Management.Models.Customer_Detail> Customer_Detail { get; set; }

        public DbSet<Electronics_Items_Management.Models.Product_Detail> Product_Detail { get; set; }

        public DbSet<Electronics_Items_Management.Models.Order_Detail> Order_Detail { get; set; }
    }
}
