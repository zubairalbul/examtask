using examtask.Models;
using examtask.Repostories;

namespace examtask.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepo _bookingRepo;
        private readonly IClinicsService _clinicsService;
        private readonly IPatientService _patientService;
        public BookingService(IBookingRepo bookingRepo1, IClinicsService clinicsService, IPatientService patientService)
        {
            _bookingRepo = bookingRepo1;
            _clinicsService = clinicsService;
            _patientService = patientService;

        }


        public List<Bookings> GetBookingsByClinic(string Clinicname)
        {
            var Clinic = _clinicsService.GetClinicByName(Clinicname);
            var Appointments = _bookingRepo.GetAll().Where(a => a.CId == Clinic.CId).ToList();
            if (Appointments == null || Appointments.Count == 0)
            {
                throw new InvalidOperationException("No Appoinntments found.");
            }

            return Appointments;


        }
        public List<Bookings> GetBookingsByPatient(string Patientname)
        {
            var Patient = _patientService.GetpatientByName(Patientname);
            var Appointments = _bookingRepo.GetAll().Where(a => a.PId == Patient.PId).ToList();
            if (Appointments == null || Appointments.Count == 0)
            {
                throw new InvalidOperationException("No Appoinntments found.");
            }
            return Appointments;
        }
        public void AddAppointment(Bookings bookings)
        {
            if (bookings.CId == 0)
            {
                throw new ArgumentException("The Clinic not found.");
            }
            if (bookings.PId == 0)
            {
                throw new ArgumentException("The Patient not found.");
            }
            if (bookings.IsBooked)
            {
                throw new ArgumentException("The Appointment is not available.");
            }
            int no_slots = _clinicsService.GetClinicById(bookings.CId).No_Slot;
            int no_bookings = _bookingRepo.GetAll().Count(a => a.BookingDate == bookings.BookingDate);
            if (no_bookings >= no_slots)
            {
                throw new ArgumentException("The Appointment is not available.");
            }

            var appointment = _bookingRepo.Add(bookings);
        }




    }
}
