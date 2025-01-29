using Microsoft.Extensions.Options;
using Tracker.Infrastructure.Authentication;

namespace Tracker.Api.Authentication;

public class JwtOptionsSetup(IConfiguration configuration) : IConfigureOptions<JwtOptions>
{
    private const string JwtSectionName = "JwtConfig";

    public void Configure(JwtOptions options)
    {
        configuration.GetSection(JwtSectionName).Bind(options);
    }
}
