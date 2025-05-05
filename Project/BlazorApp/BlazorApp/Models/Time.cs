using BlazorApp.Models;
namespace BlazorApp.Models
{
    public class Time
    {
        public int Id { get; set; }
        public string Date { get; set; }  
        public int T { get; set; }  
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
