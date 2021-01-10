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
    public class IndexModel : PageModel
    {
        private readonly Donea_Paul_App.Data.Donea_Paul_AppContext _context;

        public IndexModel(Donea_Paul_App.Data.Donea_Paul_AppContext context)
        {
            _context = context;
        }

        public IList<Maker> Maker { get;set; }

        public async Task OnGetAsync()
        {
            Maker = await _context.Maker.ToListAsync();
        }
    }
}
