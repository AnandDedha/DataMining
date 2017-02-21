namespace MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class viewStudentsEnrolled 
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string StudentName { get; set; }

        [Key]
        [Column(Order = 1)]
        public int Total_Number_Of_Courses { get; set; }
       
    }
}