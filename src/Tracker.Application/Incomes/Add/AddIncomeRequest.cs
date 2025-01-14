namespace Tracker.Application.Incomes.Add;

public sealed record AddExpenseRequest(Guid UserId, decimal Amount, string Unit, DateTime Date, string Description);