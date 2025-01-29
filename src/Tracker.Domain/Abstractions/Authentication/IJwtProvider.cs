using Tracker.Domain.Entities;

namespace Tracker.Domain.Abstractions.Authentication;

public interface IJwtProvider
{
    string GenerateJwtToken(User user);
}
