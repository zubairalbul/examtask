using examtask.Models;
using Microsoft.EntityFrameworkCore;

namespace examtask.Repostories
{
    public class BookingRepo
    {
        private readonly ApplicationDbContext _context;

        public BookingRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Bookings> GetAll()
        {
            return _context.Bookings.Include(u => u.Patients).Include(b => b.Clinics).ToList();
        }
        public Bookings GetById(int id)
        {
            return _context.Bookings.Include(u => u.Patients).Include(b => b.Clinics).FirstOrDefault(br => br.BId == id);
        }

        public void add(int  id, string Specialization, string Patient)
        {
            _context.Bookings.Add(Bookings);
            _context.SaveChanges();

        } 
    }
}
