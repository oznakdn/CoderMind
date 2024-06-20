using CoderMind.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoderMind.Persistence.Database;

public class EFContext : IdentityDbContext
{
    public EFContext(DbContextOptions<EFContext> options) : base(options)
    {
        
    }

    public DbSet<Technology> Technologies { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Content> Contents { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Technology>()
            .HasMany<Subject>()
            .WithOne(x=>x.Technology)
            .HasForeignKey(x=>x.TechnologyId);

    }
}
