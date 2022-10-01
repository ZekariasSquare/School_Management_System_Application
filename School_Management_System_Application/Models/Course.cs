using System.Collections;
using System.Collections.Generic;

namespace School_Management_System_Application.Models
{
    public partial class Course
    {
        public Course()
        {
            TeacherCourse= new HashSet<TeacherCourse>();
            StudentAttendances=new HashSet<StudentAttendance>();
            Grades=new HashSet<Grade>();
           
        }

        public long CourseId { get; set; }
        public string CourseName { get; set; }
        public int Credit_hour { get; set; }
        public long? ClassId { get; set; }






        public virtual Class Class { get; set; }

        public virtual ICollection<TeacherCourse> TeacherCourse { get; set; }
        public virtual ICollection<StudentAttendance> StudentAttendances { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }







    }
   
}
