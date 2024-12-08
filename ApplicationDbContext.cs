using examtask.Models;
using Microsoft.EntityFrameworkCore;

namespace examtask
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Patients> Patients { get; set; }
        public DbSet<Clinics> Clinics { get; set; }
        public DbSet<Bookings> Bookings { get; set; }


    }

}
