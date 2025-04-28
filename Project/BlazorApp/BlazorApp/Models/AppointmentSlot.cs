public class AppointmentSlot
{
    public int Id { get; set; }
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public DateTime Date { get; set; }
    public TimeOnly Time { get; set; }

}