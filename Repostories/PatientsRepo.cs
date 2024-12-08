using examtask.Models;


namespace examtask.Repostories
{

    public class PatientsRepo : IPatientsRepo
    {
        private readonly ApplicationDbContext _context;
        public PatientsRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public Patients GetById(int id)
        {
            return _context.Patients.FirstOrDefault(a => a.PId == id);
        }

        public int Add(Patients patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
            return patient.PId;
        }
        public void Delete(int PId)
        {
            var Patient = GetById(PId);
            if (Patient != null)
            {
                _context.Patients.Remove(Patient);
                _context.SaveChanges();
            }
        }
        public void Update(int Pid, Patients newPatient)
        {
            var currentPatient = GetById(Pid);
            if (currentPatient != null)
            {
                currentPatient.PatientName = newPatient.PatientName;
                currentPatient.age = newPatient.age;
                currentPatient.gender = newPatient.gender;
                _context.Patients.Update(currentPatient);
                _context.SaveChanges();
            }
        }
        public IEnumerable<Patients> GetAll()
        {
            return _context.Patients.ToList();
        }
    }
}
