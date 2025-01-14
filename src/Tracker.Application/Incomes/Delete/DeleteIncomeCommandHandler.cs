using Tracker.Application.Abstractions.Messaging;
using Tracker.Application.Expenses.Delete;
using Tracker.Domain.Primitives;
using Tracker.Domain.Repositories.Incomes;

namespace Tracker.Application.Incomes.Delete;

internal sealed class DeleteIncomeCommandHandler(IIncomeRepository incomeRepository, IIncomeUoW incomeUoW) : ICommandHandler<DeleteExpenseCommand, bool>
{
    public async Task<Result<bool>> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
    {
        var result = await incomeRepository.DeleteAsync(request.Id, cancellationToken);

        await incomeUoW.SaveChangesAsync(cancellationToken);

        return result.IsFailure ? Result<bool>.Failure(result.Error!) : Result<bool>.Success(result.Value);
    }
}
