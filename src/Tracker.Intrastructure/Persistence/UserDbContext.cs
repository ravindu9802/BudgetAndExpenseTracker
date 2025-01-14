using Microsoft.EntityFrameworkCore;
using Tracker.Domain.Entities;

namespace Tracker.Infrastructure.Persistence;

internal sealed class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options)
{
    private const string UserSchema = "users";

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema(UserSchema);

        modelBuilder.Entity<User>().HasIndex(u => u.Email);
    }
}
