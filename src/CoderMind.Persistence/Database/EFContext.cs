using CoderMind.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CoderMind.Persistence.Database;

public class EFContext : DbContext
{
    public EFContext(DbContextOptions<EFContext> options) : base(options)
    {
        
    }

    public DbSet<Technology> Technologies { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Content> Contents { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Technology>()
            .HasMany<Subject>()
            .WithOne(x=>x.Technology)
            .HasForeignKey(x=>x.TechnologyId);
    }
}
