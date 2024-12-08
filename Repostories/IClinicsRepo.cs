using examtask.Models;

namespace examtask.Repostories
{
    public interface IClinicsRepo
    {
        int Add(Clinics Clinic);
        void Delete(int CId);
        IEnumerable<Clinics> GetAll();
        Clinics GetById(int id);
        void Update(int Cid, Clinics newClinic);
    }
}