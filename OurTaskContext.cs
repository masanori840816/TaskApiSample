using Microsoft.EntityFrameworkCore;

namespace TaskApiSample;

public class OurTaskContext(DbContextOptions<OurTaskContext> opitons) : DbContext(opitons)
{
    public DbSet<Tasks.Models.Task> Tasks { get; set; }
}