using examtask.Models;

namespace examtask.Services
{
    public interface IBookingService
    {
        void AddAppointment(Bookings bookings);
        List<Bookings> GetBookingsByClinic(string Clinicname);
        List<Bookings> GetBookingsByPatient(string Patientname);
    }
}