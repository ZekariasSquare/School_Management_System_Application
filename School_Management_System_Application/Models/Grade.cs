using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace School_Management_System_Application.Models
{
    public partial class Grade
    {
        public Grade()
        {

        }
        [Key]
        public long? GradeId { get; set; }
        public int Roll_No { get; set; }
        public int TotalMarks { get; set; }
        public int OutOfMarks { get; set; }
        public char Grd { get; set; }
        public string PassOrFail { get; set; }
        public long? ClassId { get; set; }
        public long? CourseId { get; set; }
        public string studentId { get; set; }
        public long? Id { get; set; }



        public virtual Class classes { get; set; }
        public virtual Course course { get; set; }
        public virtual Student Student { get; set; }



    }
}
