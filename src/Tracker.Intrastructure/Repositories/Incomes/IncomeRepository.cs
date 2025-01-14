using Microsoft.EntityFrameworkCore;
using Tracker.Domain.Entities;
using Tracker.Domain.Primitives;
using Tracker.Domain.Repositories.Incomes;
using Tracker.Infrastructure.Persistence;

namespace Tracker.Infrastructure.Repositories.Incomes;

internal class IncomeRepository(IncomeDbContext incomeDbContext) : IIncomeRepository
{
    public async Task<Result<Income>> CreateAsync(Income income, CancellationToken cancellationToken)
    {
        var result = await incomeDbContext.Incomes.AddAsync(income, cancellationToken);
        return Result<Income>.Success(result.Entity);
    }

    public async Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var income = await incomeDbContext.Incomes.
            FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

        if (income is null) return Result<bool>.Failure(new Error("Income.NotFound", "Income not found."));

        incomeDbContext.Incomes.Remove(income);

        return Result<bool>.Success(true);
    }
}
