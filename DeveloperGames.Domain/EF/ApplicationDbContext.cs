using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using DeveloperGames.Domain.Entities;
using System.Data.Entity;

namespace DeveloperGames.Domain.EF
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<MatchResult> MatchResults { get; set; }
        public DbSet<UserStrategy> UserStrategies { get; set; }

        public DbSet<Leaderboard> Leaderboards { get; set; }

        public override int SaveChanges()
        {
            var saveTime = DateTime.Now;
            foreach (var entry in this.ChangeTracker.Entries().Where(e => e.State == EntityState.Added))
            {
                if (entry.Property("CreatedDate").CurrentValue == null)
                    entry.Property("CreatedDate").CurrentValue = saveTime;
            }
            return base.SaveChanges();

        }
    
    }
}
