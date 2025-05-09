using Microsoft.EntityFrameworkCore;
using BlazorApp.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Admin> Admins { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Hospital> Hospitals { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Time> Times { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Appointment>()
        .HasOne(a => a.Hospital)
        .WithMany()
        .HasForeignKey(a => a.HospitalId)
        .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<Appointment>()
        .HasOne(a => a.Patient)
        .WithMany()
        .HasForeignKey(a => a.PatientId)
        .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<Appointment>()
        .HasOne(a => a.Doctor)
        .WithMany()
        .HasForeignKey(a => a.DoctorId)
        .OnDelete(DeleteBehavior.Restrict);

    
}

}
