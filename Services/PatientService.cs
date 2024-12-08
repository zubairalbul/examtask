using examtask.Models;
using examtask.Repostories;
using System.Text.RegularExpressions;

namespace examtask.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepo _PatientsRepo;

        public PatientService(IPatientRepo patientsRepo)
        {
            _PatientsRepo = patientsRepo;
        }

        public List<patients> GetAll()
        {
            var patients = _PatientsRepo.GetAll()
                .OrderBy(a => a.PatientName)
                .ToList();
            if (patients.Count == null || patients.Count == 0)
            {
                throw new InvalidOperationException("No Patient Found");
            }
            return patients;
        }
        public patients GetpatientById(int pid)
        {
            var patient = _PatientsRepo.GetById(pid);
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
                .Where(a => a.PatientName.ToLower().Contains(name.ToLower()))

                .OrderBy(a => a.PatientName)
                .ToList();

            if (patient1 == null || patient1.Count == 0)
            {
                throw new Exception("No patient with matching name found.");
            }
            return patient1;
        }
        public void AddPatientname(patients Patient)
        {
            if (string.IsNullOrWhiteSpace(Patient.PatientName))
            {
                throw new ArgumentException("First name is required.");
            }

            if (!int.IsPositive(Patient.age))
            {
                throw new ArgumentException("Age does not match the required.");
            }
            if (string.IsNullOrEmpty(Patient.gender))
            {
                throw new ArgumentException("Gender does not match the required type.(No LGBTI ALlowed)");
            }

            _PatientsRepo.Add(Patient);


        }

    }
}
