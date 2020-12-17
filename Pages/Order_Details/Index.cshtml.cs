using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Electronics_Items_Management.Data;
using Electronics_Items_Management.Models;

namespace Electronics_Items_Management.Pages.Order_Details
{
    public class IndexModel : PageModel
    {
        private readonly Electronics_Items_Management.Data.ElectronicDatabase _context;

        public IndexModel(Electronics_Items_Management.Data.ElectronicDatabase context)
        {
            _context = context;
        }

        public IList<Order_Detail> Order_Detail { get;set; }

        public async Task OnGetAsync()
        {
            Order_Detail = await _context.Order_Detail
                .Include(o => o.Customer_Detail)
                .Include(o => o.Product_Detail).ToListAsync();
        }
    }
}
