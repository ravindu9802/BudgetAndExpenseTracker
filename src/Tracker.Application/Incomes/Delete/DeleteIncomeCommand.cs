using Tracker.Application.Abstractions.Messaging;

namespace Tracker.Application.Incomes.Delete;

public sealed record DeleteIncomeCommand(Guid Id) : ICommand<bool>;