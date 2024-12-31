using System.Collections.Generic;
using System.Reflection.Emit;
using DemoProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Context
{
    public class CandidateDbContext : DbContext
    {
        public CandidateDbContext(DbContextOptions<CandidateDbContext> options) : base(options) { }
        public DbSet<CandidateDto> CandidateDtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CandidateDto>()
                .HasIndex(c => c.Email)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
