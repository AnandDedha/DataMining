using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialMediaMiningAnandKumar.Models.SocialMedia
{
    public class Like
    {
        public int LikeId { get; set; }

        public string Name { get; set; }
        public string PostId { get; set; }
        public string FBLikeId { get; set; }

    }
}