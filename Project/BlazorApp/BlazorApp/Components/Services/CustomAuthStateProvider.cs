using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CustomAuthStateProvider(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        // Get the user's claims from the current HTTP context (cookie-based)
        var user = _httpContextAccessor.HttpContext.User;

        // Return the authentication state
        var authenticationState = new AuthenticationState(user);
        return Task.FromResult(authenticationState);
    }
    
}
