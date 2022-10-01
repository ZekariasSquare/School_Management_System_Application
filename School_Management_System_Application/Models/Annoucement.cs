using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace School_Management_System_Application.Models
{
    public class Annoucement
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Annoucement_Description { get; set; }
        public DateTime Annoucement_Date { get; set; }
        public string Annoucements { get; set; }
    }
}
