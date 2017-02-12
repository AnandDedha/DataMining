namespace SocialMediaMiningAnandKumar.Models.SocialMedia
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Post
    {
        public string PostId { get; set; }

        [Required]
        [StringLength(128)]
        public string Provider { get; set; }

        [Required]
        [StringLength(128)]
        public string ProviderPostId { get; set; }

        [Required]
        public string PostData { get; set; }

        public DateTime EditDate { get; set; }

        public DateTime CreateDate { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }
        public int LikeCount { get; internal set; }
    }
}
