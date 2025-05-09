// IAuthService.cs
public interface IAuthService
{
    Task<bool> LoginAsync(string email, string password);
}
