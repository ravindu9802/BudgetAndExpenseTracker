namespace Tracker.Domain.Repositories.Incomes;

public interface IIncomeUoW
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
