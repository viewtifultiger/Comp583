using BlazorApp.Models;
namespace BlazorApp.Models
{
public class Patient
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int Age { get; set; }
    public int HospitalId { get; set; }
    public Hospital Hospital { get; set; }
    public List<Appointment> Appointments { get; set; } = new List<Appointment>();  
}
}