using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace examtask.Models
{
    public class Patients
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PId { get; set; }
        [Required]
        public string PatientName { get; set; }
        [Required]
        public int age { get; set; }
        //[NotMapped] 
        public enum Gender { male, female }
        [Required]
        public Gender gender { get; set; }
        public List<Bookings> Bookings { get; set; }

    }
}
