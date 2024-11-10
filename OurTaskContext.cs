using Microsoft.EntityFrameworkCore;
using TaskApiSample.AppUsers.Models;

namespace TaskApiSample;

public class OurTaskContext(DbContextOptions<OurTaskContext> opitons) : DbContext(opitons)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppUser>()
            .Property(e => e.LastUpdateDate)
            .HasDefaultValueSql("SYSDATETIMEOFFSET() AT TIME ZONE 'Tokyo Standard Time'");
        modelBuilder.Entity<AppUser>()
            .HasIndex(u => u.Email)
            .IsUnique();
        modelBuilder.Entity<Tasks.Models.Task>()
            .Property(e => e.LastUpdateDate)
            .HasDefaultValueSql("SYSDATETIMEOFFSET() AT TIME ZONE 'Tokyo Standard Time'");
    }
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Tasks.Models.Task> Tasks { get; set; }
}