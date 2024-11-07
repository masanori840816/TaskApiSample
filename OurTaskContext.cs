using Microsoft.EntityFrameworkCore;

namespace TaskApiSample;

public class OurTaskContext(DbContextOptions<OurTaskContext> opitons) : DbContext(opitons)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tasks.Models.Task>()
            .Property(e => e.LastUpdateDate)
            .HasDefaultValueSql("SYSDATETIMEOFFSET() AT TIME ZONE 'Tokyo Standard Time'");
    }

    public DbSet<Tasks.Models.Task> Tasks { get; set; }
}