using examtask.Models;

namespace examtask.Services
{
    public interface IClinicsService
    {
        void AddPClinicSlot(Clinics clinic);
        List<Clinics> GetAll();
        Clinics GetClinicById(int cid);
        Clinics GetClinicByName(string name);
    }
}