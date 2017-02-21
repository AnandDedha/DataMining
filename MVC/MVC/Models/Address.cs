namespace MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Script.Serialization;

    public partial class Address
    {
        public int AddressId { get; set; }

        [StringLength(20)]
        public string City { get; set; }

        [Required]
        [StringLength(20)]
        public string ProvinceState { get; set; }

        [Required]
        [StringLength(20)]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(20)]
        public string Country { get; set; }

        public int StudentId { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime EditDate { get; set; }

        [ScriptIgnore]
        public virtual Student Student { get; set; }
    }
}
