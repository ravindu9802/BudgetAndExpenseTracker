using Tracker.Domain.Repositories.Users;
using Tracker.Infrastructure.Persistence;

namespace Tracker.Infrastructure.Repositories.Users;

internal class UserUoW(UserDbContext userDbContext) : IUserUoW
{
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await userDbContext.SaveChangesAsync(cancellationToken);
    }
}
