using Tracker.Application.Abstractions.Messaging;
using Tracker.Domain.Entities;
using Tracker.Domain.Primitives;
using Tracker.Domain.Repositories.Users;

namespace Tracker.Application.Users.Add;

internal sealed class AddUserCommandHandler(IUserRepository userRepository, IUserUoW userUoW)
    : ICommandHandler<AddUserCommand, User>
{

    public async Task<Result<User>> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await userRepository.GetUserByEmailAsync(request.Email, cancellationToken);

        if (existingUser.IsSuccess) return Result<User>.Failure(new Error("User.Exists", "User already exists."));

        var user = User.Create(Guid.CreateVersion7(), request.FirstName, request.LastName, request.Email);

        if (user.IsFailure) return Result<User>.Failure(user.Error!);

        var result = await userRepository.CreateAsync(user.Value, cancellationToken);

        await userUoW.SaveChangesAsync(cancellationToken);

        return result.IsFailure ? Result<User>.Failure(result.Error!) : Result<User>.Success(result.Value);
    }

}
