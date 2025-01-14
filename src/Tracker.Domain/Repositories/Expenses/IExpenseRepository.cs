using Tracker.Domain.Entities;
using Tracker.Domain.Primitives;

namespace Tracker.Domain.Repositories.Expenses;

public interface IExpenseRepository
{
    Task<Result<Expense>> CreateAsync(Expense expense, CancellationToken cancellationToken);
    Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken);
}
