namespace SocialMediaMiningAnandKumar.Models.SocialMedia
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class V_NumberOfLikes
    {
        [Key]
        public string ProviderPostId { get; set; }

       
        public int LikeCount { get; set; }
    }
}
