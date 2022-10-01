using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace School_Management_System_Application.Models
{
    public class Complaint
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Student_Id { get; set; }
        public DateTime Posted_Date { get; set; }
        public string Complain { get; set; }
    }
}
