namespace MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StudentLocation
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int LocationId { get; set; }

        public virtual Location Location { get; set; }

        public virtual Student Student { get; set; }
    }
}
