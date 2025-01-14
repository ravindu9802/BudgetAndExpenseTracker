using Microsoft.EntityFrameworkCore;
using Tracker.Domain.Entities;

namespace Tracker.Infrastructure.Persistence;

internal sealed class IncomeDbContext(DbContextOptions<IncomeDbContext> options) : DbContext(options)
{
    private const string IncomeSchema = "incomes";

    public DbSet<Income> Incomes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema(IncomeSchema);
    }
}
