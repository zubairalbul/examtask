﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace examtask.Models
{
    public class Clinics
    {
        [Key]
        public int CId { get; set; }
        [Required]
      
        public string Specialization { get; set; }

        [Required]

        public int No_Slot { get; set; } = 20;

        public List<Bookings> Bookings { get; set; }
    }
}