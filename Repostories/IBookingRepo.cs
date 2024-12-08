using examtask.Models;

namespace examtask.Repostories
{
    public interface IBookingRepo
    {
        void Add(Bookings appointment);
        IEnumerable<Bookings> GetAll();
        Bookings GetById(int id);
    }
}