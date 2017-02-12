using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SocialMediaMiningAnandKumar.Models;
using SocialMediaMiningAnandKumar.Models.SocialMedia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SocialMediaMiningAnandKumar.Controllers
{
    

    [Authorize]
    public class FacebookController : Controller
    {

        private DataContext db = new DataContext();
        //    private ApplicationUserManager _userManager;
        //    public ApplicationUserManager UserManager
        //    {
        //        get
        //        {
        //            return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //        }
        //        private set
        //        {
        //            _userManager = value;
        //        }
        //    }

        // GET: Facebook
        public ActionResult Index()
        {
            return View();
        }
       /// <summary>
       /// 
       /// </summary>
       /// <returns></returns>
       public async Task<ActionResult> Posts()
        {
        Models.SocialMedia.Facebook.FacebookClient faceBookClient = new Models.SocialMedia.Facebook.FacebookClient();
        faceBookClient.HttpContext = HttpContext;
        Models.SocialMedia.Facebook.posts posts = await faceBookClient.Posts();

            using (db)
            {
                foreach (var post in posts.feed.data)
                {
                    var TempGUID = Guid.NewGuid().ToString();
                    Post p = new Post();
                    p.PostId = TempGUID;
                    p.CreateDate = DateTime.Now;
                    p.EditDate = DateTime.Now;
                    p.UserId = HttpContext.User.Identity.GetUserId();
                    p.LikeCount = post.likes.data.Length;
                    p.PostData = System.Web.Helpers.Json.Encode(post); // Converting post object into json
                    p.Provider = "facebook";
                    p.ProviderPostId = post.id;
                    db.Posts.Add(p);
                    db.SaveChanges();
                    foreach (var like in post.likes.data)
                    {
                        Like L = new Like();
                        L.PostId = TempGUID;
                        L.Name = like.name;
                        L.FBLikeId = like.id;
                        db.Likes.Add(L);
                        db.SaveChanges();
                    }

                }
                
                
            }
        return (View(posts));   
       
        
        //String connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\SocialMediaMining.mdf;Initial Catalog=SocialMediaMining;Integrated Security=True";
  
            //  var currentClaims = await UserManager.GetClaimsAsync(HttpContext.User.Identity.GetUserId());
            //var accesstoken = currentClaims.FirstOrDefault(X => X.Type == "urn:tokens:facebook");
            //if(accesstoken == null)
            //{
            //    return (new HttpStatusCodeResult(HttpStatusCode.NotFound,"Token Not Found"));
            //}
            //string url = string.Format("https://graph.facebook.com/me?fields=id,name,feed.limit(10){{attachments{{description,type,url,media,target}},comments{{id,from,message}},story,likes{{id,name}}}}&access_token={0}", accesstoken.Value);
            //HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            //request.Method = "GET";
            //using(HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse)
            //{

            //    StreamReader reader = new StreamReader(response.GetResponseStream());
            //    string result = await reader.ReadToEndAsync();
            //    dynamic jsonObj = System.Web.Helpers.Json.Decode(result);
            //    Models.SocialMedia.Facebook.posts posts = new Models.SocialMedia.Facebook.posts(jsonObj);
            //    using (SqlConnection connection = new SqlConnection(connectionString))
            //    {
            //        connection.Open();
            //        foreach (var post in posts.feed.data)
            //        {
            //            SqlCommand cmd = new SqlCommand("INSERT INTO Data ([Like]) VALUES(" + post.likes.data.Length + ")");
            //            cmd.CommandType = CommandType.Text;
            //            cmd.Connection = connection;
            //            //cmd.Parameters.AddWithValue("@Like", posts.name);
            //            //cmd.Parameters.AddWithValue("@PhoneNo", txtPhone.Text);
            //            //cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
            //            cmd.ExecuteNonQuery();
            //        }
            //    }
            //    ViewBag.JSON = result;
            //    return View(posts);
            //}

                
        }

        public ActionResult LikeGraphView()
        {
            return View();
        }

        public JsonResult GetLikesCount()
        {
            var viewLikeCount = db.V_NumberOfLikes;

            return (Json(viewLikeCount, JsonRequestBehavior.AllowGet));
        }

    }
}