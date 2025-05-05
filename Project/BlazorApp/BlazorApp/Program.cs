using BlazorApp.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorApp.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<AppointmentService>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add authentication and authorization services
builder.Services.AddAuthorizationCore();

// Register authentication with cookie authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";  // Path to redirect if the user is not authenticated
        options.LogoutPath = "/login"; // Path to redirect after logging out
    });
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add CustomAuthStateProvider to manage authentication state
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // Ensure the database is created
    context.Database.Migrate();

    // Declare hospital variables outside of the if-else block
    Hospital hospital = null;
    Hospital hospital2 = null;
    Hospital hospital3 = null;
    Hospital hospital4 = null;

    // Seed hospitals
    // Only seed if there are no hospitals yet
    if (!context.Hospitals.Any())
    {
        hospital = new Hospital { Name = "Henry Mayo" };
        hospital2 = new Hospital { Name = "Providence" };
        hospital3 = new Hospital { Name = "UCLA Health" };
        hospital4 = new Hospital { Name = "Kaiser Permanente" };

        context.Hospitals.AddRange(hospital, hospital2, hospital3, hospital4);
        context.SaveChanges();
    }
    else
    {
        // Load existing hospitals from DB
        hospital = context.Hospitals.FirstOrDefault(h => h.Name == "Henry Mayo");
        hospital2 = context.Hospitals.FirstOrDefault(h => h.Name == "Providence");
        hospital3 = context.Hospitals.FirstOrDefault(h => h.Name == "UCLA Health");
        hospital4 = context.Hospitals.FirstOrDefault(h => h.Name == "Kaiser Permanente");
    }

    // Ensure hospitals were loaded or created correctly
    if (hospital == null || hospital2 == null || hospital3 == null || hospital4 == null)
    {
        throw new Exception("One or more hospitals not found or created.");
    }

    // Seed admins, doctors, and patients...
    var admin = new Admin
    {
        FirstName = "Alice",
        LastName = "Smith",
        Email = "alice@example.com",
        Password = "password",
        Age = 35,
        HospitalId = hospital.Id
    };
    context.Admins.Add(admin);
    var admin2 = new Admin
    {
        FirstName = "John",
        LastName = "Doe",
        Email = "john@example.com",
        Password = "password",
        Age = 43,
        HospitalId = hospital2.Id
    };
    context.Admins.Add(admin2);
    var admin3 = new Admin
    {
        FirstName = "Jane",
        LastName = "Doe",
        Email = "jane@example.com",
        Password = "password",
        Age = 25,
        HospitalId = hospital3.Id
    };
    context.Admins.Add(admin3);
    var admin4 = new Admin
    {
        FirstName = "Ronald",
        LastName = "Donald",
        Email = "Ronald@example.com",
        Password = "password",
        Age = 50,
        HospitalId = hospital4.Id
    };
    context.Admins.Add(admin4);

    // Seed doctors and patients similarly...

    context.SaveChanges();
}

// Use authentication and authorization middleware
app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
