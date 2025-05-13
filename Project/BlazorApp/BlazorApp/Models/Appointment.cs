using BlazorApp.Models;
namespace BlazorApp.Models
{  
    public class Appointment
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public Patient Patient { get; set; }  
    
    public int HospitalId { get; set; }
    public Hospital Hospital { get; set; }  
    
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }  
    
    public DateTime Date { get; set; }  
    public String time { get; set; }
}
}



