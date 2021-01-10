using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Donea_Paul_App.Data;
using Donea_Paul_App.Models;

namespace Donea_Paul_App.Pages.Trucks
{
    public class CreateModel : PageModel
    {
        private readonly Donea_Paul_App.Data.Donea_Paul_AppContext _context;

        public CreateModel(Donea_Paul_App.Data.Donea_Paul_AppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["MakerID"] = new SelectList(_context.Set<Maker>(), "ID", "MakerName");
            return Page();
        }

        [BindProperty]
        public Truck Truck { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Truck.Add(Truck);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
