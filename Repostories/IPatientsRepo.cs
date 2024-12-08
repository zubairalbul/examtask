using examtask.Models;

namespace examtask.Repostories
{
    public interface IPatientRepo
    {
        int Add(patients patient);
        void Delete(int PId);
        IEnumerable<patients> GetAll();
        patients GetById(int id);
        void Update(int Pid, patients newPatient);
    }
}