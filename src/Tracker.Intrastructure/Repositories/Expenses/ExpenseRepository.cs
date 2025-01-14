using Microsoft.EntityFrameworkCore;
using Tracker.Domain.Entities;
using Tracker.Domain.Primitives;
using Tracker.Domain.Repositories.Expenses;
using Tracker.Infrastructure.Persistence;

namespace Tracker.Infrastructure.Repositories.Expenses;

internal class ExpenseRepository(ExpenseDbContext expenseDbContext) : IExpenseRepository
{
    public async Task<Result<Expense>> CreateAsync(Expense expense, CancellationToken cancellationToken)
    {
        var result = await expenseDbContext.Expenses.AddAsync(expense, cancellationToken);
        return Result<Expense>.Success(result.Entity);
    }

    public async Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var income = await expenseDbContext.Expenses.
            FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

        if (income is null) return Result<bool>.Failure(new Error("Expense.NotFound", "Expense not found."));

        expenseDbContext.Expenses.Remove(income);

        return Result<bool>.Success(true);
    }
}
