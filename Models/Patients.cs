using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace examtask.Models
{
    public class patients
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PId { get; set; }
        [Required]
        public string PatientName { get; set; }
        [Required]
        public int age { get; set; }
        //[NotMapped] 
       
        [Required]
        public string gender { get; set; }
        [JsonIgnore]
        public List<Bookings> Bookings { get; set; }

    }
}
