using Microsoft.EntityFrameworkCore;

namespace _3lab;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Manager> Managers { get; set; }
}
