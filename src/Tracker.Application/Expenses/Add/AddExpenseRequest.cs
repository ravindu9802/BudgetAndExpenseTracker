namespace Tracker.Application.Expenses.Add;

public sealed record AddIncomeRequest(Guid UserId, decimal Amount, string Unit, DateTime Date, string Description);