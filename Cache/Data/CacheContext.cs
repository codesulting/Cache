using Microsoft.EntityFrameworkCore;

namespace Cache.Data
{
    public class CacheContext : DbContext
    {
        public CacheContext (
            DbContextOptions<CacheContext> options)
            : base(options)
        {
        }

        public DbSet<Cache.Models.Firearm> Firearm { get; set; }
    }
}