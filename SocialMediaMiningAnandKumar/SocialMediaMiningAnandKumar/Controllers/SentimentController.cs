using SocialMediaMiningAnandKumar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace SocialMediaMiningAnandKumar.Controllers
{
    public class SentimentController : Controller
    {
        // GET: Sentiment
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string sentence)
        {
            using (DataContext db = new DataContext())
            {
                IEnumerable<Phrase> Phrases = db.Phrases.Include(w => w.Word);
                string newsentence = sentence.Replace("I don't hate", "like");
                foreach(Phrase phrase in Phrases)
                {
                    //newsentence = newsentence.Replace(phrase.phrase, phrase.Word.Word);
                }

                string[] words = sentence.Split(' ');

                IEnumerable<Word> Words = db.Words;
                List<Word> values = new List<Word>();

            }
            return View();
        }
    }
}