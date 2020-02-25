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
    public class EditModel : BasePageModel
    {

        public EditModel(
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

            Firearm = await Context.Firearm.FirstOrDefaultAsync(
                f => f.Id == id && f.UserId == currentUserId);

            if (Firearm == null)
            {
                return NotFound();
            }
            return Page();

        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Context.Attach(Firearm).State = EntityState.Modified;

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FirearmExists(Firearm.Id))
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

        private bool FirearmExists(int id)
        {
            return Context.Firearm.Any(e => e.Id == id);
        }
    }
}
