using examtask.Models;

namespace examtask.Services
{
    public class PatientService 
    {
        private readonly PatientService _PatientsRepo;

        public PatientService(PatientService patientsRepo)
        {
            _PatientsRepo = patientsRepo;
        }

        public List<patients> GetAll()
        {
            var patients =_PatientsRepo.GetAll()
                .OrderBy(a=> a.PatientName)
                .ToList();
            if (patients.Count == null || patients.Count == 0 )
            {
                throw new InvalidOperationException("No Patient Found");
            }
            return patients;
        }
        public patients GetpatientById(int pid)
        {
            var patient = _PatientsRepo.GetpatientById(pid);
            if (patient == null)
            {
                throw new KeyNotFoundException("patient not found.");
            }
            return patient;
        }
        public patients GetpatientByName(string name)
        {
            var patientname = _PatientsRepo.GetAll().FirstOrDefault(a => a.PatientName == name);
            if (patientname == null)
            {
                throw new KeyNotFoundException("patient not found.");
            }
            return patientname;
        }
        public List<patients> GetPatientByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Search term entered is null.");
            }
            var patient1 = _PatientsRepo.GetAll()
                .Where(a => a.PatientName.ToLower().Contains(name.ToLower())
                || a.PatientName.ToLower().Contains(name.ToLower())
                || name.ToLower().Contains(a.PatientName.ToLower()))
                
                .OrderBy(a => a.PatientName)
                .ToList();

            if (patient1 == null || patient1.Count == 0)
            {
                throw new Exception("No patient with matching name found.");
            }
            return patient1;
        }

    }
}
