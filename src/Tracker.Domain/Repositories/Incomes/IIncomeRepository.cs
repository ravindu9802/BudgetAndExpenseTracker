using Tracker.Domain.Entities;
using Tracker.Domain.Primitives;

namespace Tracker.Domain.Repositories.Incomes;

public interface IIncomeRepository
{
    Task<Result<Income>> CreateAsync(Income income, CancellationToken cancellationToken);
    Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken);
}
