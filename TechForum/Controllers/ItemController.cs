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
    public class ItemController : Controller
    {
        // GET: Item

        public ActionResult Index()
        {
            using (ItemContext db = new ItemContext())
            {
                var Topics = db.Topics;
                return View(Topics.ToList());
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult CreateTopic()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateTopic(Topic model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (ItemContext db = new ItemContext())
            {

                Topic topic = new Topic();

                if (db.Topics.Where(x => x.Id != model.Id).Any(x => x.Title == model.Title))
                {
                    ModelState.AddModelError("Title", "Topic with such title already exists");
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

                topic.Title = model.Title;
                topic.PostDate = DateTime.Now;
                topic.Text = model.Text;
                topic.UserName = User.Identity.Name;
                topic.Posts = new List<Post>();

                db.Topics.Add(topic);
                db.SaveChanges();
            }

            TempData["SM"] = "You have added a new page";

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            using (ItemContext db = new ItemContext())
            {
                var topic = db.Topics.Find(id);

                db.Topics.Remove(topic);

                db.SaveChanges();
            }

            TempData["SM"] = "You have deleted a new page successfully";
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            using (ItemContext db = new ItemContext())
            {
                var topic = db.Topics.Find(id);
                return View(topic);
            }
        }
    }
}