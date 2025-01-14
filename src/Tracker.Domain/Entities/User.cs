using Tracker.Domain.Primitives;

namespace Tracker.Domain.Entities;

public sealed class User : Entity
{
    private User() { }

    private User(Guid id, string firstName, string lastName, string email): base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    //public string Password { get; private set; }
    public DateTime CreatedAtUtc { get; private set; } = DateTime.UtcNow;

    public static Result<User> Create(Guid id, string firstName, string lastName, string email)
    {
        if (string.IsNullOrWhiteSpace(id.ToString()))
            return Result<User>.Failure(new Error("User.Id", "Id cannot be empty."));

        if (string.IsNullOrWhiteSpace(firstName))
            return Result<User>.Failure(new Error("User.InvalidFirstName", "First name cannot be empty."));

        if (string.IsNullOrWhiteSpace(lastName))
            return Result<User>.Failure(new Error("User.InvalidLastName", "Last name cannot be empty."));

        if (string.IsNullOrWhiteSpace(email))
            return Result<User>.Failure(new Error("User.InvalidEmail", "Email cannot be empty."));

        //TODO: Validate existing emails

        return Result<User>.Success(new User(id, firstName, lastName, email));
    }

    public Result<bool> Login(string email, string password)
    {
        if (!Email.Equals(email))
            return Result<bool>.Failure(new Error("User.InvalidCredentials", "Invalid Email or Password."));

        //if (!Password.Equals(password))
        //    return Result<bool>.Failure(new Error("User.InvalidCredentials", "Invalid Email or Password."));

        return Result<bool>.Success(true);
    }
}
