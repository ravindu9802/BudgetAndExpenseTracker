namespace Tracker.Application.Users.Login;

public sealed record LoginUserResponse(Guid Id, string Email, string AccessToken);