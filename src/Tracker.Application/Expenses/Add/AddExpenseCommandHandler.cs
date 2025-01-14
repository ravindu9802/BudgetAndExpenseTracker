using Tracker.Application.Abstractions.Messaging;
using Tracker.Domain.Entities;
using Tracker.Domain.Primitives;
using Tracker.Domain.Repositories.Expenses;
using Tracker.Domain.Repositories.Users;

namespace Tracker.Application.Expenses.Add;

internal sealed class AddExpenseCommandHandler(IExpenseRepository expenseRepository, IExpenseUoW expenseUoW, IUserRepository userRepository) : ICommandHandler<AddExpenseCommand, Expense>
{
    public async Task<Result<Expense>> Handle(AddExpenseCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await userRepository.GetUserByIdAsync(request.UserId, cancellationToken);

        if (existingUser.IsFailure) return Result<Expense>.Failure(new Error("User.NotFound", "User id is invalid."));

        var expense = Expense.Create(Guid.CreateVersion7(), request.UserId, request.Amount, request.Unit, request.Date, request.Description);

        if (expense.IsFailure) return Result<Expense>.Failure(expense.Error!);

        var result = await expenseRepository.CreateAsync(expense.Value, cancellationToken);

        await expenseUoW.SaveChangesAsync(cancellationToken);

        return result.IsFailure ? Result<Expense>.Failure(result.Error!) : Result<Expense>.Success(result.Value);
    }
}
