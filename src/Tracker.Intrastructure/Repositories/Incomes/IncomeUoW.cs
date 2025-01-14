using Tracker.Domain.Repositories.Incomes;
using Tracker.Infrastructure.Persistence;

namespace Tracker.Infrastructure.Repositories.Incomes;

internal class IncomeUoW(IncomeDbContext incomeDbContext) : IIncomeUoW
{
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await incomeDbContext.SaveChangesAsync(cancellationToken);
    }
}
