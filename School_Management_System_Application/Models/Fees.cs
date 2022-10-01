using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace School_Management_System_Application.Models
{
    public partial class Fees
    {
        public Fees()
        {

        }
        [Key]
        public long FeeID { get; set; }
        public long? ClassID { get; set; }
        public long Amount { get; set; }


        public virtual Class Class { get; set; }


    }
}
