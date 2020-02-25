using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Cache.Data;
using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Cache.Models
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw)
        {

            var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

            var testUserId = await EnsureUser(serviceProvider, testUserPw, "admin@test.com");

            SeedFirearms(context, testUserId);

        }

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
            string testUserPw, string email)
        {

            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            var user = await userManager.FindByNameAsync(email);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = email,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, testUserPw);
            }

            if (user == null)
            {
                throw new Exception("The password is probably not strong enough!");
            }

            return user.Id;

        }

        public static void SeedFirearms(ApplicationDbContext context, string testUserId)
        {

            // Look for any firearms.
            if (context.Firearm.Any())
            {
                // DB has been seeded
                return;
            }

            context.Firearm.AddRange(
                new Firearm
                {
                    UserId = testUserId,
                    ManufacturerImporter = "Bravo Company Manufacturing",
                    Model = "BCM4",
                    SerialNumber = "A123456",
                    Type = FirearmType.Rifle,
                    CaliberGauge = "5.56mm NATO",
                    DateAcquired = DateTime.Parse("2019-04-01"),
                    Cost = 1500.00M,
                    PurchaseLocation = "Palmetto State Armory",
                    SoldTransferredTo = "",
                    Notes = ""
                },

                new Firearm
                {
                    UserId = testUserId,
                    ManufacturerImporter = "Daniel Defense",
                    Model = "DDM4V11 Pro",
                    SerialNumber = "DDM1234567",
                    Type = FirearmType.Rifle,
                    CaliberGauge = "5.56mm NATO",
                    DateAcquired = DateTime.Parse("2019-09-01"),
                    Cost = 1999.99M,
                    PurchaseLocation = "Palmetto State Armory",
                    SoldTransferredTo = "",
                    Notes = ""
                }
            );
            context.SaveChanges();

        }

    }
}