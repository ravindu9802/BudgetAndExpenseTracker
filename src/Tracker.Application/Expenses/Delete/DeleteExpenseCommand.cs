using Tracker.Application.Abstractions.Messaging;

namespace Tracker.Application.Expenses.Delete;

public sealed record DeleteExpenseCommand(Guid Id) : ICommand<bool>;