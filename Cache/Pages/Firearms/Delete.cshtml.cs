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
    public class DeleteModel : BasePageModel
    {

        public DeleteModel(
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
            : base(context, userManager)
        {
        }

        [BindProperty]
        public Firearm Firearm { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var currentUserId = UserManager.GetUserId(User);

            Firearm = await Context.Firearm.Where(
                f => f.Id == id && f.UserId == UserManager.GetUserId(User)
            ).FirstOrDefaultAsync();

            if (Firearm == null)
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

            Firearm = await Context.Firearm.Where(
                f => f.Id == id && f.UserId == UserManager.GetUserId(User)
            ).FirstOrDefaultAsync();

            if (Firearm != null)
            {
                Context.Firearm.Remove(Firearm);
                await Context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
            
        }
    }
}
