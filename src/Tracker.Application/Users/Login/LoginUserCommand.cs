using Tracker.Application.Abstractions.Messaging;
using Tracker.Domain.Primitives;

namespace Tracker.Application.Users.Login;

public sealed record LoginUserCommand(string Email) : ICommand<LoginUserResponse>;