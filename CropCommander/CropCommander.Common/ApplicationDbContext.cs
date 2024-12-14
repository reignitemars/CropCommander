using CropCommander.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace CropCommander.Common;

public class ApplicationDbContext : DbContext
{
    public DbSet<Field> Fields { get; set; } // Represents the Fields table in the database
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Field entity
        modelBuilder.Entity<Field>(entity =>
        {
            entity.HasKey(e => e.Id); // Primary key
            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()"); // PostgreSQL-specific UUID generator
        });
    }
}