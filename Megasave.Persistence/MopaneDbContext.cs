using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Megasave.Domain.Entities;
using Megasave.Domain.Entities.Base;

namespace Megasave.Persistence
{
    public class MopaneDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MopaneDbContext(DbContextOptions<MopaneDbContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<Branches> Branches { get; set; }
        public DbSet<Activities> Activities { get; set; }
        public DbSet<Alerts> Alerts { get; set; }
        public DbSet<Banks> Banks { get; set; }
        public DbSet<Batches> Batches { get; set; }
        public DbSet<CashRequests> CashRequests { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Emails> Emails { get; set; }
        public DbSet<Files> Files { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<PayTypes> PayTypes { get; set; }
        public DbSet<Supplies> Suppliers { get; set; }
        public DbSet<Targets> Targets { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<BatchesHistory> BatchesHistory { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MopaneDbContext).Assembly);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>()
                .HavePrecision(18, 6);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.Updated = DateTime.Now;
                        entry.Entity.LastModifiedBy = _httpContextAccessor.HttpContext?.User?.Identities.FirstOrDefault()
                            ?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                        break;
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = _httpContextAccessor.HttpContext?.User?.Identities.FirstOrDefault()
                            ?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}