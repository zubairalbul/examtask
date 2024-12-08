using examtask.Models;

namespace examtask.Repostories
{
    public class ClinicsRepo : IClinicsRepo
    {
        private readonly ApplicationDbContext _context;
        public ClinicsRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Clinics> GetAll()
        {
            return _context.Clinics.ToList();
        }
        public Clinics GetById(int id)
        {
            return _context.Clinics.FirstOrDefault(a => a.CId == id);
        }

        public int Add(Clinics Clinic)
        {
            _context.Clinics.Add(Clinic);
            _context.SaveChanges();
            return Clinic.CId;
        }
        public void Delete(int CId)
        {
            var Clinic = GetById(CId);
            if (Clinic != null)
            {
                _context.Clinics.Remove(Clinic);
                _context.SaveChanges();
            }
        }
        public void Update(int Cid, Clinics newClinic)
        {
            var currentClinic = GetById(Cid);
            if (currentClinic != null)
            {
                currentClinic.Specialization = newClinic.Specialization;
                currentClinic.No_Slot = newClinic.No_Slot;
                _context.SaveChanges();
            }
        }

    }
}
