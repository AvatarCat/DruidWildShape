using System;
using Microsoft.EntityFrameworkCore;

namespace DruidShapeshifting.Models
{
    public class DruidShapeshiftingContext : DbContext
    {
        public DruidShapeshiftingContext (DbContextOptions<DruidShapeshiftingContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Creature>()
            .HasOne(c => c.Druid)
            .WithMany(d => d.Creatures)
            .HasForeignKey(c => c.DruidId)
            .IsRequired(false);
        }

        public DbSet<DruidShapeshifting.Models.Druid> Druid { get; set; }
        public DbSet<DruidShapeshifting.Models.Creature> Creature {get; set;}
    }
}