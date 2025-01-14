using Tracker.Application.Abstractions.Messaging;
using Tracker.Domain.Entities;

namespace Tracker.Application.Expenses.Add;

public sealed record AddExpenseCommand(Guid UserId, decimal Amount, string Unit, DateTime Date, string Description) : ICommand<Expense>;
