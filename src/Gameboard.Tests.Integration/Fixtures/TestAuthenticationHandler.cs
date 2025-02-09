using System.Security.Claims;
using System.Text.Encodings.Web;
using Gameboard.Api;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Gameboard.Tests.Integration.Fixtures;

internal class TestAuthenticationHandler : AuthenticationHandler<TestAuthenticationHandlerOptions>
{
    private readonly string _defaultUserId;

    public const string AuthenticationSchemeName = "Test";
    public AuthenticationScheme AuthScheme { get; } = new AuthenticationScheme(name: AuthenticationSchemeName, displayName: AuthenticationSchemeName, handlerType: typeof(TestAuthenticationHandler));

    public TestAuthenticationHandler(IOptionsMonitor<TestAuthenticationHandlerOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) :
        base(options, logger, encoder, clock)
    {
        _defaultUserId = options.CurrentValue.DefaultUserId;
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, "Integration tester"),
            new Claim(ClaimTypes.NameIdentifier, _defaultUserId),
            new Claim(AppConstants.SubjectClaimName, _defaultUserId),
            new Claim(AppConstants.ApprovedNameClaimName, "Integration Tester"),
            new Claim(AppConstants.RoleListClaimName, UserRole.Admin.ToString())
        };

        var identity = new ClaimsIdentity(claims, AuthScheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, AuthScheme.Name);

        return Task.FromResult(AuthenticateResult.Success(ticket));
    }
}
