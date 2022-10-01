using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace School_Management_System_Application.Models
{
    public partial class TeacherCourse
    {
        public TeacherCourse()
        {

        }
        [Key]
        public long TcId { get; set; }
        public long? ClassId { get; set; }
        public long? CourseId { get; set; }
        public long? TeacherID { get; set; }


        public virtual Class Class { get; set; }
        public virtual Course Course { get; set; }
        public virtual Teacher Teacher { get; set; }



    }
}
