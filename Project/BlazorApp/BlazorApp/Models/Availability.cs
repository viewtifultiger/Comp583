using BlazorApp.Models;
namespace BlazorApp.Models
{
public class Availability
{
    public int Id { get; set; }
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }

    public DateTime Date { get; set; }
    public string TimeSlot { get; set; }
    public bool IsAvailable { get; set; }
}
}

