namespace MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EmailAddress
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        [StringLength(264)]
        public string URI { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        public int StudentId { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime EditDate { get; set; }

        public virtual Student Student { get; set; }
    }
}
