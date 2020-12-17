using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Electronics_Items_Management.Data;
using Electronics_Items_Management.Models;

namespace Electronics_Items_Management.Pages.Product_Details
{
    public class IndexModel : PageModel
    {
        private readonly Electronics_Items_Management.Data.ElectronicDatabase _context;

        public IndexModel(Electronics_Items_Management.Data.ElectronicDatabase context)
        {
            _context = context;
        }

        public IList<Product_Detail> Product_Detail { get;set; }

        public async Task OnGetAsync()
        {
            Product_Detail = await _context.Product_Detail
                .Include(p => p.Brand_Detail)
                .Include(p => p.Category_Detail).ToListAsync();
        }
    }
}
