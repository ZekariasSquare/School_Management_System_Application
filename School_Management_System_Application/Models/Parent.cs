using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace School_Management_System_Application.Models
{
    public partial class Parent
    {
        public Parent()
        {

        }
        [Key]
        public int ParentId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string password { get; set; }
        public string Email { get; set; }
        

       
    }
}
