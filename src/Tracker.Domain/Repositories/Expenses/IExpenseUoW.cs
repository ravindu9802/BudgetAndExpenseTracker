namespace Tracker.Domain.Repositories.Expenses;

public interface IExpenseUoW
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
