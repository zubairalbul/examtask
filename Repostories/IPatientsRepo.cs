using examtask.Models;

namespace examtask.Repostories
{
    public interface IPatientsRepo
    {
        int Add(Patients patient);
        void Delete(int PId);
        IEnumerable<Patients> GetAll();
        Patients GetById(int id);
        void Update(int Pid, Patients newPatient);
    }
}