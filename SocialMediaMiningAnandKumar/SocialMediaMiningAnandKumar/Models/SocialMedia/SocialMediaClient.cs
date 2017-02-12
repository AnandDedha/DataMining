using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Net;

namespace SocialMediaMiningAnandKumar.Models.SocialMedia
{
    public class SocialMediaClient
    {
        public string baseUrl { get; set; }
        public HttpContextBase HttpContext { get; set; }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
            {
                get
                {
                    return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                }
                private set
                {
                    _userManager = value;
                }
            }
        public string ProviderKey { get; set; }
        public string AccessToken { get; set; }
        public async Task<System.Security.Claims.Claim> GetAccessToken()
        {
            if(HttpContext == null)
            {
                return(null);
            }
            string userId = HttpContext.User.Identity.GetUserId();
            return (await GetAccessToken(userId));
        }

        public async Task <System.Security.Claims.Claim> GetAccessToken(string userId)
        {   //Get Access Token
            var currentClaims = await UserManager.GetClaimsAsync(userId);
            var accesstoken = currentClaims.FirstOrDefault(X => X.Type == String.Format( "urn:tokens:{0}", ProviderKey));
            if (accesstoken == null)
            {
                return (null);
            }
            AccessToken = accesstoken.Value;
            return (accesstoken);
        }

        public async Task<dynamic> Get(string url)
        {
            
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            using (HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse)
            {

                StreamReader reader = new StreamReader(response.GetResponseStream());
                string result = await reader.ReadToEndAsync();
                dynamic jsonObj = System.Web.Helpers.Json.Decode(result);
                return (jsonObj);
            }


        }

    }
}