using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Electronics_Items_Management.Data;
using Electronics_Items_Management.Models;

namespace Electronics_Items_Management.Pages.Product_Details
{
    public class CreateModel : PageModel
    {
        private readonly Electronics_Items_Management.Data.ElectronicDatabase _context;

        public CreateModel(Electronics_Items_Management.Data.ElectronicDatabase context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Brand_DetailId"] = new SelectList(_context.Brand_Detail, "Id", "Brand_Name");
        ViewData["Category_DetailId"] = new SelectList(_context.Category_Detail, "Id", "Product");
            return Page();
        }

        [BindProperty]
        public Product_Detail Product_Detail { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Product_Detail.Add(Product_Detail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
