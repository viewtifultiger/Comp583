using BlazorApp.Models;
namespace BlazorApp.Models
{
public class Hospital
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Doctor> Doctors { get; set; } = new List<Doctor>(); 
    public List<Patient> Patients { get; set; } = new List<Patient>();  
    public List<Admin> Admins { get; set; } = new List<Admin>();  
}
}
