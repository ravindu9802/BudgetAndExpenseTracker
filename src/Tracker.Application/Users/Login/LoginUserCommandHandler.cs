using Tracker.Application.Abstractions.Messaging;
using Tracker.Domain.Abstractions.Authentication;
using Tracker.Domain.Primitives;
using Tracker.Domain.Repositories.Users;

namespace Tracker.Application.Users.Login;

internal class LoginUserCommandHandler(IUserRepository userRepository, IJwtProvider jwtProvider): ICommandHandler<LoginUserCommand, LoginUserResponse>
{

    public async Task<Result<LoginUserResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
       var user = await userRepository.GetUserByEmailAsync(request.Email, cancellationToken);

       if(user.IsFailure) return Result<LoginUserResponse>.Failure(user.Error!);

       var token = jwtProvider.GenerateJwtToken(user.Value);

        return Result<LoginUserResponse>.Success(new LoginUserResponse(user.Value.Id, user.Value.Email, token));
    }
}
