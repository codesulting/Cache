using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cache.Data;
using Cache.Models;

namespace Cache.Pages.Firearms
{
    public class IndexModel : BasePageModel
    {

        public IndexModel(
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
            : base(context, userManager)
        {
        }

        public IList<Firearm> Firearm { get; set; }

        public async Task OnGetAsync()
        {

            var currentUserId = UserManager.GetUserId(User);

            Firearm = await Context.Firearm.Where(
                f => f.UserId == currentUserId).ToListAsync();

        }
    }
}
