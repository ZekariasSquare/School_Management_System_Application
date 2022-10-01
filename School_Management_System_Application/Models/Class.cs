using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace School_Management_System_Application.Models
{
    public partial class Class

    {
        public Class()
        {
            Courses = new HashSet<Course>();
            Students = new HashSet<Student>();
            TeacherCourses = new HashSet<TeacherCourse>();
            StudentAttendances = new HashSet<StudentAttendance>();
            Fees = new HashSet<Fees>();
            Grades= new HashSet<Grade>();
        }
        public long ClassId { get; set; }
        public string ClassName { get; set; }


        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<TeacherCourse> TeacherCourses { get; set; }
        public virtual ICollection<StudentAttendance> StudentAttendances { get; set; }
        public virtual ICollection<Fees> Fees { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
