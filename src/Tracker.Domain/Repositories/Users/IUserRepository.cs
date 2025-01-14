using Tracker.Domain.Entities;
using Tracker.Domain.Primitives;

namespace Tracker.Domain.Repositories.Users;

public interface IUserRepository
{
    Task<Result<User>> CreateAsync(User user, CancellationToken cancellationToken);
    Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<Result<User>> GetUserByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Result<User>> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
}
