using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
#nullable disable
namespace School_Management_System_Application.Models
{
    public partial class Student
    {

        public Student()
        {
            Grades = new HashSet<Grade > ();

        }

        [Key]
        public long Id { get; set; }
        public string Student_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public long Phone_No { get; set; }
        public long Roll_No { get; set; }
        public DateTime DOB { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string Email { get; set; }
        public long? ClassId { get; set; }



        public virtual Class Class { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }






    }
    
   
}
