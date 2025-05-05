using BlazorApp.Models;

public class AppointmentService
{
    private readonly List<Appointment> _appointments = new();

    public IReadOnlyList<Appointment> Appointments => _appointments;

    public void AddAppointment(Appointment appointment)
    {
        _appointments.Add(appointment);
    }
}
