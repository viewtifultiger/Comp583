using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;


public class AuthService : IAuthService
{
    private readonly AppDbContext _dbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly NavigationManager _navigationManager;

    public AuthService(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor, NavigationManager navigationManager)
    {
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;
        _navigationManager = navigationManager;
    }

    public async Task<bool> LoginAsync(string email, string password)
    {
        object user = null;
        string dbPassword = null;
        string role = null;

        var doctor = await _dbContext.Doctors.FirstOrDefaultAsync(d => d.Email == email);
        if (doctor != null)
        {
            user = doctor;
            dbPassword = doctor.Password;
            role = "Doctor";
        }

        if (user == null)
        {
            var patient = await _dbContext.Patients.FirstOrDefaultAsync(p => p.Email == email);
            if (patient != null)
            {
                user = patient;
                dbPassword = patient.Password;
                role = "Patient";
            }
        }

        if (user == null)
        {
            var admin = await _dbContext.Admins.FirstOrDefaultAsync(a => a.Email == email);
            if (admin != null)
            {
                user = admin;
                dbPassword = admin.Password;
                role = "Admin";
            }
        }
        if (user != null && BCrypt.Net.BCrypt.Verify(password, dbPassword))
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, email),
                new Claim(ClaimTypes.Role, role)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            _navigationManager.NavigateTo("/Home");
            return true;
        }

        return false;
    }
}
