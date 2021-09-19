using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechForum.Models;

namespace TechForum.Controllers
{
    public class PostContentController : Controller
    {
        // GET: PostContent
        public ActionResult Index(int id)
        {
            using(ItemContext db = new ItemContext())
            {
                var post = db.Posts.Find(id);
                return View(post);
            }            
        }
    }
}