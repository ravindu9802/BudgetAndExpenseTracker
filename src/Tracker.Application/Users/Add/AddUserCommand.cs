using Tracker.Application.Abstractions.Messaging;
using Tracker.Domain.Entities;

namespace Tracker.Application.Users.Add;

public sealed record AddUserCommand(string FirstName, string LastName, string Email) : ICommand<User>;