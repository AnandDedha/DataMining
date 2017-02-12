namespace SocialMediaMiningAnandKumar.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Word
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Word()
        {
            Phrases = new HashSet<Phrase>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int WordId { get; set; }

        [Column("Word")]
        [Required]
        [StringLength(50)]
        public string Word1 { get; set; }

        public int Value { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phrase> Phrases { get; set; }
    }
}
