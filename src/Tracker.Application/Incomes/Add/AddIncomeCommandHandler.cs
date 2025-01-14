using Tracker.Application.Abstractions.Messaging;
using Tracker.Domain.Entities;
using Tracker.Domain.Primitives;
using Tracker.Domain.Repositories.Incomes;
using Tracker.Domain.Repositories.Users;

namespace Tracker.Application.Incomes.Add;

internal sealed class AddIncomeCommandHandler(IIncomeRepository incomeRepository, IIncomeUoW incomeUoW, IUserRepository userRepository) : ICommandHandler<AddIncomeCommand, Income>
{
    public async Task<Result<Income>> Handle(AddIncomeCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await userRepository.GetUserByIdAsync(request.UserId, cancellationToken);

        if (existingUser.IsFailure) return Result<Income>.Failure(new Error("User.NotFound", "User id is invalid."));

        var income = Income.Create(Guid.CreateVersion7(), request.UserId, request.Amount, request.Unit, request.Date, request.Description);

        if (income.IsFailure) return Result<Income>.Failure(income.Error!);

        var result = await incomeRepository.CreateAsync(income.Value, cancellationToken);

        await incomeUoW.SaveChangesAsync(cancellationToken);

        return result.IsFailure ? Result<Income>.Failure(result.Error!) : Result<Income>.Success(result.Value);
    }
}
