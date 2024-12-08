using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace examtask.Models
{
    [PrimaryKey(nameof(BId), nameof(PId), nameof(CId))]
    public class Bookings
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BId { get; set; }
        [ForeignKey("Patients")]
    
        public int slot_number { get; set; }
        public int PId { get; set; }
        [ForeignKey("Clinics")]
        public int CId { get; set; }
        [Required]
        public DateTime BookingDate { get; set; }
        
        public bool IsBooked { get; set; }=false;
        public virtual Patients Patients { get; set; }
        public virtual Clinics Clinics { get; set; }
    }
}
