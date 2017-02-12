namespace SocialMediaMiningAnandKumar.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phrases")]
    public partial class Phrase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PhraseId { get; set; }

        [Required]
        [StringLength(50)]
        public string phrase { get; set; }

        public int WordId { get; set; }

        public virtual Word Word { get; set; }
    }
}
