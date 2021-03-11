using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class MonDbContext : DbContext
    {
        public MonDbContext(DbContextOptions<MonDbContext> options) : base(options)
        {


        }

        public DbSet<Formation> Formations { get; set; }

        public DbSet<Avis> Avis { get; set; }
        public DbSet<ContactMessage> Messages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Formation>()
                .Property(f => f.Description)
                .HasMaxLength(500);
        }

    }
}
