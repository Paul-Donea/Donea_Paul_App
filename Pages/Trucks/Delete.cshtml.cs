using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Donea_Paul_App.Data;
using Donea_Paul_App.Models;

namespace Donea_Paul_App.Pages.Trucks
{
    public class DeleteModel : PageModel
    {
        private readonly Donea_Paul_App.Data.Donea_Paul_AppContext _context;

        public DeleteModel(Donea_Paul_App.Data.Donea_Paul_AppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Truck Truck { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Truck = await _context.Truck.FirstOrDefaultAsync(m => m.ID == id);

            if (Truck == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Truck = await _context.Truck.FindAsync(id);

            if (Truck != null)
            {
                _context.Truck.Remove(Truck);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
