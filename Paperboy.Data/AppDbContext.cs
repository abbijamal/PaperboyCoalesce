using Microsoft.EntityFrameworkCore;
using Paperboy.Data.Models;

namespace Paperboy.Data;

[Coalesce]
public class AppDbContext : DbContext
{
    public DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();

    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Remove cascading deletes.
        foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
