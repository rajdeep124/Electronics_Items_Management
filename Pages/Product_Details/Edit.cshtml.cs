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

namespace Electronics_Items_Management.Pages.Product_Details
{
    public class EditModel : PageModel
    {
        private readonly Electronics_Items_Management.Data.ElectronicDatabase _context;

        public EditModel(Electronics_Items_Management.Data.ElectronicDatabase context)
        {
            _context = context;
        }

        [BindProperty]
        public Product_Detail Product_Detail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product_Detail = await _context.Product_Detail
                .Include(p => p.Brand_Detail)
                .Include(p => p.Category_Detail).FirstOrDefaultAsync(m => m.Id == id);

            if (Product_Detail == null)
            {
                return NotFound();
            }
           ViewData["Brand_DetailId"] = new SelectList(_context.Brand_Detail, "Id", "Brand_Name");
           ViewData["Category_DetailId"] = new SelectList(_context.Category_Detail, "Id", "Product");
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

            _context.Attach(Product_Detail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Product_DetailExists(Product_Detail.Id))
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

        private bool Product_DetailExists(int id)
        {
            return _context.Product_Detail.Any(e => e.Id == id);
        }
    }
}
