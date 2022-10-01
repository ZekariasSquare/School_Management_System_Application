using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace School_Management_System_Application.Models
{
    public partial class Teacher
    {

        public Teacher()
        {
            TeacherCourses = new HashSet<TeacherCourse>();
        }



        [Key]
        public long Id { get; set; }
        [Required]
        public string username { get; set; }
        public string password { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string gender { get; set; }
        public double Phone_no { get; set; }
        public string email { get; set; }


        public virtual ICollection<TeacherCourse> TeacherCourses { get; set; }

    }
}
