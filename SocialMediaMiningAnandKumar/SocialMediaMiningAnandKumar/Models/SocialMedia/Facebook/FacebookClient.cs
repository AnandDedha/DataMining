using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SocialMediaMiningAnandKumar.Models.SocialMedia.Facebook
{
    public class FacebookClient : SocialMediaClient
    {
        public string FeedUrl { get; set; } = "me?fields=id,name,feed.limit(10){attachments{description,type,url,media,target},comments{id,from,message},story,likes{id,name}}";
        public FacebookClient()
        {
            ProviderKey = "facebook";
            baseUrl = "https://graph.facebook.com/";
        }

        public async Task<posts> Posts()
        {
            //Access Token
            await GetAccessToken();

            string url = String.Format("{0}{1}&access_token={2}", baseUrl, FeedUrl, AccessToken);

            //Get Data
            dynamic jsonObj = await Get(url);

            //JSON
            Models.SocialMedia.Facebook.posts posts = new Models.SocialMedia.Facebook.posts(jsonObj);
            return (posts);
        }
    }
}