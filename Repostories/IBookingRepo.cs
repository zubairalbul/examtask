using examtask.Models;

namespace examtask.Repostories
{
    public interface IBookingRepo
    {
        (DateTime, string, string) Add(Bookings appointment);
        IEnumerable<Bookings> GetAll();
        Bookings GetById(int id);
    }
}