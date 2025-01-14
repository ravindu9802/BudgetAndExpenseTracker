using Tracker.Application.Abstractions.Messaging;
using Tracker.Domain.Primitives;
using Tracker.Domain.Repositories.Users;

namespace Tracker.Application.Users.Delete;

internal sealed class DeleteUserCommandHandler(IUserRepository userRepository, IUserUoW userUoW)
    : ICommandHandler<DeleteUserCommand, bool>
{

    public async Task<Result<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {

        var result = await userRepository.DeleteAsync(request.Id, cancellationToken);

        await userUoW.SaveChangesAsync(cancellationToken);

        return result.IsFailure ? Result<bool>.Failure(result.Error!) : Result<bool>.Success(result.Value);
    }

}
