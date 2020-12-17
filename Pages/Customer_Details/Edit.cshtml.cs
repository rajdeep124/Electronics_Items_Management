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

namespace Electronics_Items_Management.Pages.Customer_Details
{
    public class EditModel : PageModel
    {
        private readonly Electronics_Items_Management.Data.ElectronicDatabase _context;

        public EditModel(Electronics_Items_Management.Data.ElectronicDatabase context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Customer_Detail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Customer_DetailExists(Customer_Detail.Id))
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

        private bool Customer_DetailExists(int id)
        {
            return _context.Customer_Detail.Any(e => e.Id == id);
        }
    }
}
