using Tracker.Application.Abstractions.Messaging;

namespace Tracker.Application.Users.Delete;

public sealed record DeleteUserCommand(Guid Id) : ICommand<bool>;