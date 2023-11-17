using Megasave.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Megasave.Identity
{
    public class MopaneIdentityDbContext : IdentityDbContext<Users>
    {
        public MopaneIdentityDbContext(DbContextOptions<MopaneIdentityDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MopaneIdentityDbContext).Assembly);
            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasNoKey();
            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasKey(c => new { c.UserId, c.RoleId });
            modelBuilder.Entity<IdentityUserToken<string>>()
                .HasNoKey();
            modelBuilder.Entity<IdentityRole>()
                .HasKey(c => c.Id);
        }
    }
}