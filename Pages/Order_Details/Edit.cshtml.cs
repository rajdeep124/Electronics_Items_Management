using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Electronics_Items_Management.Data;
using Electronics_Items_Management.Models;

namespace Electronics_Items_Management.Pages.Order_Details
{
    public class EditModel : PageModel
    {
        private readonly Electronics_Items_Management.Data.ElectronicDatabase _context;

        public EditModel(Electronics_Items_Management.Data.ElectronicDatabase context)
        {
            _context = context;
        }

        [BindProperty]
        public Order_Detail Order_Detail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order_Detail = await _context.Order_Detail
                .Include(o => o.Customer_Detail)
                .Include(o => o.Product_Detail).FirstOrDefaultAsync(m => m.Id == id);

            if (Order_Detail == null)
            {
                return NotFound();
            }
           ViewData["Customer_DetailId"] = new SelectList(_context.Customer_Detail, "Id", "Customer_Name");
           ViewData["Product_DetailId"] = new SelectList(_context.Product_Detail, "Id", "Product_Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Order_Detail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Order_DetailExists(Order_Detail.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool Order_DetailExists(int id)
        {
            return _context.Order_Detail.Any(e => e.Id == id);
        }
    }
}
