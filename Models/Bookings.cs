using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Text.Json.Serialization;

namespace examtask.Models
{
    [PrimaryKey(nameof(BId), nameof(PId), nameof(CId))]
    public class Bookings
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int BId { get; set; }
        
    
        public int slot_number { get; set; }
        [ForeignKey("Patients")]
        public int PId { get; set; }
        [ForeignKey("Clinics")]
        public int CId { get; set; }
        [Required]
        public DateTime BookingDate { get; set; }
        
        public bool IsBooked { get; set; }=false;
        [JsonIgnore]
        public virtual patients Patients { get; set; }
        public virtual Clinics Clinics { get; set; }
    }
}
