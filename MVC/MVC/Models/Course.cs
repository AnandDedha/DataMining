namespace MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Script.Serialization;

    [Table("Courses")]
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            StudentCourses = new HashSet<StudentCourse>();
        }

        [Key]
        public int CourseId { get; set; }

        [Required]
        [StringLength(20)]
        public string Coursecode { get; set; }

        [Required]
        [StringLength(30)]
        public string CourseName { get; set; }

        public bool IsOnline { get; set; }

        [StringLength(36)]
        public string Instructor { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime EditDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [ScriptIgnore]
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
