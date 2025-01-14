using Tracker.Domain.Primitives;

namespace Tracker.Domain.Entities;

public sealed class Expense : Entity
{
    private Expense() { }

    private Expense(Guid id, Guid userId, decimal amount, string unit, DateTime date, string description) : base(id)
    {
        UserId = userId;
        Amount = amount;
        Unit = unit;
        Date = date;
        Description = description;
    }

    public Guid UserId { get; private set; }
    public decimal Amount { get; private set; }
    public string Unit { get; private set; }
    public DateTime Date { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedAtUtc { get; private set; } = DateTime.UtcNow;

    public static Result<Expense> Create(Guid id, Guid userId, decimal amount, string unit, DateTime date,
        string description)
    {
        if (string.IsNullOrWhiteSpace(id.ToString()))
            return Result<Expense>.Failure(new Error("Expense.Id", "Id cannot be empty."));

        if (string.IsNullOrWhiteSpace(userId.ToString()))
            return Result<Expense>.Failure(new Error("Expense.UserId", "User id cannot be empty."));

        if (amount <= 0)
            return Result<Expense>.Failure(new Error("Expense.InvalidAmount", "Amount must be greater than zero."));

        if (string.IsNullOrWhiteSpace(unit))
            return Result<Expense>.Failure(new Error("Expense.InvalidUnit", "Expense unit cannot be empty."));

        if (unit.Length != 3)
            return Result<Expense>.Failure(new Error("Expense.InvalidUnit", "Expense unit is invalid."));

        if (date > DateTime.UtcNow)
            return Result<Expense>.Failure(new Error("Expense.InvalidDate", "Date cannot be in the future."));

        if (string.IsNullOrWhiteSpace(description))
            return Result<Expense>.Failure(new Error("Expense.InvalidDescription", "Description cannot be empty."));

        date = date.ToUniversalTime();

        return Result<Expense>.Success(new Expense(id, userId, amount, unit, date, description));
    }

}
