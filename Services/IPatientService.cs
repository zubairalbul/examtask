using examtask.Models;

namespace examtask.Services
{
    public interface IPatientService
    {
        void AddPatientname(patients Patient);
        List<patients> GetAll();
        patients GetpatientById(int pid);
        patients GetpatientByName(string name);
        List<patients> GetPatientByName(string name);
    }
}