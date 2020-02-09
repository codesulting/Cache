using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Cache.Data;
using System;
using System.Linq;

namespace Cache.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CacheContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CacheContext>>()))
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
                        ManufacturerImporter = "Bravo Company Manufacturing",
                        Model = "BCM4",
                        SerialNumber = "A123456",
                        Type = "Long Gun",
                        CaliberGauge = "5.56mm NATO",
                        DateAcquired = DateTime.Parse("2019-04-01"),
                        Cost = 1500.00M,
                        PurchaseLocation = "",
                        SoldTransferredTo = ""
                    },

                    new Firearm
                    {
                        ManufacturerImporter = "Daniel Defense",
                        Model = "DDM4V11 Pro",
                        SerialNumber = "DDM1234567",
                        Type = "Long Gun",
                        CaliberGauge = "5.56mm NATO",
                        DateAcquired = DateTime.Parse("2019-09-01"),
                        Cost = 1999.99M,
                        PurchaseLocation = "",
                        SoldTransferredTo = ""
                    }
                );
                context.SaveChanges();
            }
        }
    }
}