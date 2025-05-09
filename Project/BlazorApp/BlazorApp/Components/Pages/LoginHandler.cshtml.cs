using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

public class LoginHandlerModel : PageModel
{/*
    private readonly AppDbContext _dbContext;

    public LoginHandlerModel(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IActionResult> OnPostAsync(string username, string password)
    {
        object user = null;
        string dbPassword = null;
        string role = null;

        // Try to find the user in each of the roles
        var doctor = await _dbContext.Doctors.FirstOrDefaultAsync(d => d.Email == username);
        var patient = await _dbContext.Patients.FirstOrDefaultAsync(p => p.Email == username);
        var admin = await _dbContext.Admins.FirstOrDefaultAsync(a => a.Email == username);

        if (doctor != null)
        {
            user = doctor;
            dbPassword = doctor.Password;
            role = "Doctor";
        }
        else if (patient != null)
        {
            user = patient;
            dbPassword = patient.Password;
            role = "Patient";
        }
        else if (admin != null)
        {
            user = admin;
            dbPassword = admin.Password;
            role = "Admin";
        }

        // Compare the passwords directly (no hashing)
        if (user != null && dbPassword == password)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return Redirect("/Home");
        }

        // Failed login
        return Redirect("/?loginFailed=true");
    }
*/}


