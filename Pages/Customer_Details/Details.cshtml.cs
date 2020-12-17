using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Electronics_Items_Management.Data;
using Electronics_Items_Management.Models;

namespace Electronics_Items_Management.Pages.Customer_Details
{
    public class DetailsModel : PageModel
    {
        private readonly Electronics_Items_Management.Data.ElectronicDatabase _context;

        public DetailsModel(Electronics_Items_Management.Data.ElectronicDatabase context)
        {
            _context = context;
        }

        public Customer_Detail Customer_Detail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer_Detail = await _context.Customer_Detail.FirstOrDefaultAsync(m => m.Id == id);

            if (Customer_Detail == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
