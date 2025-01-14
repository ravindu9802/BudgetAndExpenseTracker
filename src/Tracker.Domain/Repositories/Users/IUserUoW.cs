namespace Tracker.Domain.Repositories.Users;

public interface IUserUoW
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
