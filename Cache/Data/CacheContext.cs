using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cache.Data
{
    public class CacheContext : IdentityDbContext
    {
        public CacheContext (
            DbContextOptions<CacheContext> options)
            : base(options)
        {
        }

        public DbSet<Cache.Models.Firearm> Firearm { get; set; }
    }
}