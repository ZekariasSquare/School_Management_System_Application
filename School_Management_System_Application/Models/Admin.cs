using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School_Management_System_Application.Models
{
    public class Admin
    {
        [Key]
        public int AId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string password { get; set; }
    }
}
