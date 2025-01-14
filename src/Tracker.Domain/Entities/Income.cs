using Tracker.Domain.Primitives;

namespace Tracker.Domain.Entities;

public sealed class Income : Entity
{
    private Income() { }

    private Income(Guid id, Guid userId, decimal amount, string unit, DateTime date, string description) : base(id)
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

    public static Result<Income> Create(Guid id, Guid userId, decimal amount, string unit, DateTime date, string description)
    {
        if (string.IsNullOrWhiteSpace(id.ToString()))
            return Result<Income>.Failure(new Error("Income.Id", "Id cannot be empty."));

        if (string.IsNullOrWhiteSpace(userId.ToString()))
            return Result<Income>.Failure(new Error("Income.UserId", "User id cannot be empty."));

        if (amount <= 0)
            return Result<Income>.Failure(new Error("Income.InvalidAmount", "Amount must be greater than zero."));

        if (string.IsNullOrWhiteSpace(unit))
            return Result<Income>.Failure(new Error("Income.InvalidUnit", "Income unit cannot be empty."));

        if (unit.Length != 3)
            return Result<Income>.Failure(new Error("Income.InvalidUnit", "Income unit is invalid."));

        if (date > DateTime.UtcNow)
            return Result<Income>.Failure(new Error("Income.InvalidDate", "Date cannot be in the future."));

        if (string.IsNullOrWhiteSpace(description))
            return Result<Income>.Failure(new Error("Income.InvalidDescription", "Description cannot be empty."));

        //Todo: Check if user exists

        date = date.ToUniversalTime();

        return Result<Income>.Success(new Income(id, userId, amount, unit, date, description));
    }

}
