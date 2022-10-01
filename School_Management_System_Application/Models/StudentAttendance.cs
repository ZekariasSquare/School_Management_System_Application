using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace School_Management_System_Application.Models
{
    public partial class StudentAttendance
    {
        public StudentAttendance()
        {

        }

        [Key]
        public long AttendanceId { get; set; }
        public int roll_no { get; set; }
        public DateTime AttendanceDate { get; set; }
        public long? ClassId { get; set; }
        public long? CourseId { get; set; }



        public virtual Class Class { get; set; }
        public virtual Course Course { get; set; }
    }
}
