using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechForum.Models;
using TechForum.Models.Items;

namespace TechForum.Controllers
{
    public class PostsController : Controller
    {
        
        public ActionResult Init(int id)
        {
            Session["TopicId"] = id;
            return RedirectToAction("Index");
        }

        // GET: Topic
        public ActionResult Index()
        {
            
            using (ItemContext db = new ItemContext())
            {
                var Posts = db.Topics.Find(Session["TopicId"]).Posts;

                return View(Posts.ToList());
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost(Post model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (ItemContext db = new ItemContext())
            {

                Post post = new Post();



                var topic = db.Topics.Find(Session["TopicId"]);
                var posts = topic.Posts;

                if (posts.Any(x => x.Title == model.Title))
                {
                    ModelState.AddModelError("", "Post with such title already exist");
                    return View(model);
                } 
                if (model.Text.IsNullOrWhiteSpace())
                {
                    ModelState.AddModelError("Text", "Please enter text");
                    return View(model);
                }

                if (model.Title.IsNullOrWhiteSpace())
                {
                    ModelState.AddModelError("Title", "Please enter title");
                    return View(model);
                }
                else if (model.Title.Length < 3 || model.Title.Length > 20)
                {
                    ModelState.AddModelError("Title", "Title length must be in range from 3 to 20");
                    return View(model);
                }
                
                    post.Title = model.Title;
                    post.PostDate = DateTime.Now;
                    post.Text = model.Text;
                    post.UserName = User.Identity.Name;
                    post.Topic = topic;
                    posts.Add(post);
                    db.SaveChanges();
                

            }

            TempData["SM"] = "You have added a new post";

            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult DeletePost(int id)
        {
            using (ItemContext db = new ItemContext())
            {
                var posts = db.Posts;


                foreach (var i in posts.ToList())
                {
                    if (i.PostId == id)
                    {
                        posts.Remove(i);
                    }
                }

                db.SaveChanges();
            }

            TempData["SM"] = "You have deleted a new page successfully";
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditPost(int id)
        {

            using (ItemContext db = new ItemContext())
            {
                Post post = db.Posts.Find(id);

                if (post == null)
                {
                    return Content("This page does not exist.");
                }

                return View(post);
            }

        }
        [HttpPost]
        public ActionResult EditPost(Post model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (ItemContext db = new ItemContext())
            {
                int id = model.PostId;


                Post post = db.Posts.Find(id);

                post.Title = model.Title;

                if (db.Posts.Where(x => x.PostId != id).Any(x => x.Title == model.Title))
                {
                    ModelState.AddModelError("", "This title already exists");
                    return View(model);
                }

                post.Text = model.Text;

                db.SaveChanges();
            }
            TempData["SM"] = "Post was successfully edited";
            return RedirectToAction("Index");

        }
    }
}