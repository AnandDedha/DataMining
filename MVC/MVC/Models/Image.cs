namespace MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Image
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ImageId { get; set; }

        [Required]
        [StringLength(20)]
        public string ImageName { get; set; }

        [StringLength(140)]
        public string ImageDescription { get; set; }

        [Required]
        [StringLength(250)]
        public string ImageLocation { get; set; }

        public int ImageSize { get; set; }

        [Column("Image")]
        [Required]
        public byte[] Image1 { get; set; }

        public int StudentId { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime EditDate { get; set; }

        public virtual Student Student { get; set; }
    }
}
