using Microsoft.EntityFrameworkCore;
using Tracker.Domain.Entities;
using Tracker.Domain.Primitives;
using Tracker.Domain.Repositories.Users;
using Tracker.Infrastructure.Persistence;

namespace Tracker.Infrastructure.Repositories.Users;

internal class UserRepository(UserDbContext userDbContext) : IUserRepository
{
    public async Task<Result<User>> CreateAsync(User user, CancellationToken cancellationToken)
    {
        var result = await userDbContext.Users.AddAsync(user, cancellationToken);
        return Result<User>.Success(result.Entity);
    }

    public async Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await userDbContext.Users.
            FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

        if (user is null) return Result<bool>.Failure(new Error("User.NotFound", "User not found."));

        userDbContext.Users.Remove(user);

        return Result<bool>.Success(true);
    }

    public async Task<Result<User>> GetUserByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await userDbContext.Users
            .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

        if (user is null) return Result<User>.Failure(new Error("User.NotFound", "User not found."));

        return Result<User>.Success(user);
    }

    public async Task<Result<User>> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
    {
        var user = await userDbContext.Users
            .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);

        if (user is null) return Result<User>.Failure(new Error("User.NotFound", "User not found."));

        return Result<User>.Success(user);
    }
}
