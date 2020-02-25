using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cache.Data;
using Cache.Models;

namespace Cache.Pages.Firearms
{
    public class IndexModel : PageModel
    {
        private readonly Cache.Data.CacheContext _context;

        public IndexModel(Cache.Data.CacheContext context)
        {
            _context = context;
        }

        public IList<Firearm> Firearm { get;set; }

        public async Task OnGetAsync()
        {
            Firearm = await _context.Firearm.ToListAsync();
        }
    }
}
