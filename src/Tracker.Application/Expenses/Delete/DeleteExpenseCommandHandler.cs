using Tracker.Application.Abstractions.Messaging;
using Tracker.Domain.Primitives;
using Tracker.Domain.Repositories.Expenses;

namespace Tracker.Application.Expenses.Delete;

internal sealed class DeleteExpenseCommandHandler(IExpenseRepository expenseRepository, IExpenseUoW expenseUoW) : ICommandHandler<DeleteExpenseCommand, bool>
{
    public async Task<Result<bool>> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
    {
        var result = await expenseRepository.DeleteAsync(request.Id, cancellationToken);

        await expenseUoW.SaveChangesAsync(cancellationToken);

        return result.IsFailure ? Result<bool>.Failure(result.Error!) : Result<bool>.Success(result.Value);
    }
}
