using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cache.Data;
using Cache.Models;

namespace Cache.Pages.Firearms
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly Cache.Data.CacheContext _context;

        public DetailsModel(Cache.Data.CacheContext context)
        {
            _context = context;
        }

        public Firearm Firearm { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Firearm = await _context.Firearm.FirstOrDefaultAsync(m => m.Id == id);

            if (Firearm == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
