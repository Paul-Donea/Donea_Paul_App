using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Donea_Paul_App.Data;
using Donea_Paul_App.Models;

namespace Donea_Paul_App.Pages.Makers
{
    public class DetailsModel : PageModel
    {
        private readonly Donea_Paul_App.Data.Donea_Paul_AppContext _context;

        public DetailsModel(Donea_Paul_App.Data.Donea_Paul_AppContext context)
        {
            _context = context;
        }

        public Maker Maker { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Maker = await _context.Maker.FirstOrDefaultAsync(m => m.ID == id);

            if (Maker == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
