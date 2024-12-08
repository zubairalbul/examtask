using examtask.Models;
using examtask.Repostories;

namespace examtask.Services
{
    public class ClinicsService : IClinicsService
    {
        private readonly IClinicsRepo _clinicsRepo;

        public ClinicsService(IClinicsRepo clinicsRepo)
        {
            _clinicsRepo = clinicsRepo;
        }

        public List<Clinics> GetAll()
        {
            var clinicses = _clinicsRepo.GetAll()
                .OrderBy(a => a.Specialization)
                .ToList();
            if (clinicses.Count == null || clinicses.Count == 0)
            {
                throw new InvalidOperationException("No Clinic Found");
            }
            return clinicses;
        }
        public Clinics GetClinicById(int cid)
        {
            var Clinicses = _clinicsRepo.GetById(cid);
            if (Clinicses == null)
            {
                throw new KeyNotFoundException("Clinic not found.");
            }
            return Clinicses;
        }
        public Clinics GetClinicByName(string name)
        {
            var Specialization = _clinicsRepo.GetAll().FirstOrDefault(a => a.Specialization == name);
            if (Specialization == null)
            {
                throw new KeyNotFoundException("patient not found.");
            }
            return Specialization;
        }
        public void AddPClinicSlot(Clinics clinic)
        {
            if (string.IsNullOrWhiteSpace(clinic.Specialization))
            {
                throw new ArgumentException("Specializations is required.");
            }

            if (!int.IsPositive(clinic.No_Slot))
            {
                throw new ArgumentException("number does not match the required.");
            }


            _clinicsRepo.Add(clinic);


        }

    }
}
