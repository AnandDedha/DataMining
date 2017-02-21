namespace MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class viewStudentsInCourses
    {

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string CourseName { get; set; }

        [Key]
        [Column(Order = 1)]
        public int TotalStudents { get; set; }

    }
}
