using BlazorApp.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorApp.Models;
using Server;
using Server.Controllers;
using BCrypt.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddSingleton<AppointmentService>();
builder.Services.AddRazorPages();
builder.Services.AddHttpClient();

// Add Blazor Server components and interactive rendering
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddAuthorizationCore();

// Authentication configuration
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
        options.LogoutPath = "/logout"; 
    });

// Configure database context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add custom authentication state provider for Blazor
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddHttpContextAccessor();

// Configure HttpClient for API requests
builder.Services.AddHttpClient("BlazorApp", client =>
{
    client.BaseAddress = new Uri("http://localhost:5113/"); // Ensure correct URL for API calls
});
builder.Services.AddAuthorization();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin() 
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


var app = builder.Build();
app.UseCors();
app.MapControllers();
//app.MapGet("/login", () => "API is running.");

// Database seeding logic
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.Migrate();

    // Seed Hospitals
    Hospital hospital = context.Hospitals.FirstOrDefault(h => h.Name == "Henry Mayo") ?? new Hospital { Name = "Henry Mayo" };
    Hospital hospital2 = context.Hospitals.FirstOrDefault(h => h.Name == "Providence") ?? new Hospital { Name = "Providence" };
    Hospital hospital3 = context.Hospitals.FirstOrDefault(h => h.Name == "UCLA Health") ?? new Hospital { Name = "UCLA Health" };
    Hospital hospital4 = context.Hospitals.FirstOrDefault(h => h.Name == "Kaiser Permanente") ?? new Hospital { Name = "Kaiser Permanente" };

    if (hospital.Id == 0 || hospital2.Id == 0 || hospital3.Id == 0 || hospital4.Id == 0)
    {
        context.Hospitals.AddRange(
            hospital.Id == 0 ? hospital : null,
            hospital2.Id == 0 ? hospital2 : null,
            hospital3.Id == 0 ? hospital3 : null,
            hospital4.Id == 0 ? hospital4 : null
        );
        context.SaveChanges();
    }

    // Seed Admins with hashed passwords
    if (!context.Admins.Any(a => a.Email == "alice@example.com"))
    {
        context.Admins.Add(new Admin
        {
            FirstName = "Alice",
            LastName = "Smith",
            Email = "alice@example.com",
            Password = "password",
            Age = 35,
            HospitalId = hospital.Id
        });
    }

    if (!context.Admins.Any(a => a.Email == "john@example.com"))
    {
        context.Admins.Add(new Admin
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john@example.com",
            Password = "password",
            Age = 43,
            HospitalId = hospital2.Id
        });
    }

    if (!context.Admins.Any(a => a.Email == "jane@example.com"))
    {
        context.Admins.Add(new Admin
        {
            FirstName = "Jane",
            LastName = "Doe",
            Email = "jane@example.com",
            Password = "password",
            Age = 25,
            HospitalId = hospital3.Id
        });
    }

    if (!context.Admins.Any(a => a.Email == "ronald@example.com"))
    {
        context.Admins.Add(new Admin
        {
            FirstName = "Ronald",
            LastName = "Donald",
            Email = "ronald@example.com",
            Password = "password",
            Age = 50,
            HospitalId = hospital4.Id
        });
    }

    // Seed Doctors with hashed passwords
    if (!context.Doctors.Any(d => d.Email == "harold@example.com"))
    {
        context.Doctors.Add(new Doctor
        {
            FirstName = "Harold",
            LastName = "John",
            Email = "harold@example.com",
            Password = "password",
            Age = 28,
            HospitalId = hospital.Id
        });
    }

    if (!context.Doctors.Any(d => d.Email == "alex@example.com"))
    {
        context.Doctors.Add(new Doctor
        {
            FirstName = "Alex",
            LastName = "Jones",
            Email = "alex@example.com",
            Password = "password",
            Age = 30,
            HospitalId = hospital2.Id
        });
    }

    if (!context.Doctors.Any(d => d.Email == "joe@example.com"))
    {
        context.Doctors.Add(new Doctor
        {
            FirstName = "Joe",
            LastName = "Jones",
            Email = "joe@example.com",
            Password = "password",
            Age = 45,
            HospitalId = hospital3.Id
        });
    }

    if (!context.Doctors.Any(d => d.Email == "johnny@example.com"))
    {
        context.Doctors.Add(new Doctor
        {
            FirstName = "Johnny",
            LastName = "Guitar",
            Email = "johnny@example.com",
            Password = "password",
            Age = 32,
            HospitalId = hospital4.Id
        });
    }

    // Seed Patients with hashed passwords
    if (!context.Patients.Any(p => p.Email == "jay@example.com"))
    {
        context.Patients.Add(new Patient
        {
            FirstName = "Jay",
            LastName = "Jackson",
            Email = "jay@example.com",
            Password = "password",
            Age = 28,
            HospitalId = hospital.Id
        });
    }

    if (!context.Patients.Any(p => p.Email == "steve@example.com"))
    {
        context.Patients.Add(new Patient
        {
            FirstName = "Steve",
            LastName = "Hoover",
            Email = "steve@example.com",
            Password = "password",
            Age = 27,
            HospitalId = hospital2.Id
        });
    }

    if (!context.Patients.Any(p => p.Email == "jenny@example.com"))
    {
        context.Patients.Add(new Patient
        {
            FirstName = "Jenny",
            LastName = "Mcgee",
            Email = "jenny@example.com",
            Password = "password",
            Age = 33,
            HospitalId = hospital3.Id
        });
    }

    if (!context.Patients.Any(p => p.Email == "jake@example.com"))
    {
        context.Patients.Add(new Patient
        {
            FirstName = "Jake",
            LastName = "Sanders",
            Email = "jake@example.com",
            Password = "password",
            Age = 38,
            HospitalId = hospital4.Id
        });
    }

    context.SaveChanges();
}

// Middleware setup
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapRazorPages();
app.MapStaticAssets();
app.MapGet("/", () => Results.Redirect("/Login"));
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
