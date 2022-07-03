using System.Linq;
using Imi.Project.Herexamen.Api.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Imi.Project.Herexamen.Api.Infrastructure.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Participation> Participations { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<CombatRole> CombatRoles { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Map>()
                .HasMany(m => m.Operations)
                .WithOne(o => o.Map);

            modelBuilder.Entity<CombatRole>()
                .HasMany(cr => cr.Users)
                .WithOne(u => u.CombatRole);

            modelBuilder.Entity<Participation>()
                .ToTable("Participation")
                .HasKey(p => new { p.UserId, p.OperationId });
            modelBuilder.Entity<Participation>()
                .HasOne(p => p.User)
                .WithMany(u => u.Participations)
                .HasForeignKey(p => p.UserId);
            modelBuilder.Entity<Participation>()
                .HasOne(p => p.Operation)
                .WithMany(o => o.Participations)
                .HasForeignKey(p => p.OperationId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.CombatRole)
                .WithMany(cr => cr.Users);

            modelBuilder.Entity<Operation>()
                .HasOne(o => o.Map)
                .WithMany(m => m.Operations);

            DataSeeder.SeedData(modelBuilder);
        }
    }
}