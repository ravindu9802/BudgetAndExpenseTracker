using Tracker.Application.Abstractions.Messaging;
using Tracker.Domain.Entities;

namespace Tracker.Application.Incomes.Add;

public sealed record AddIncomeCommand(Guid UserId, decimal Amount, string Unit, DateTime Date, string Description) : ICommand<Income>;
