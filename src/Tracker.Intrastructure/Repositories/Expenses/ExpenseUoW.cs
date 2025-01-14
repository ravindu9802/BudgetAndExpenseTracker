using Tracker.Domain.Repositories.Expenses;
using Tracker.Infrastructure.Persistence;

namespace Tracker.Infrastructure.Repositories.Expenses;

internal class ExpenseUoW(ExpenseDbContext expenseDbContext) : IExpenseUoW
{
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await expenseDbContext.SaveChangesAsync(cancellationToken);
    }
}
