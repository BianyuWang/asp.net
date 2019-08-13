using BlogMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace BlogMvc.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
           
            var posts = db.Posts.Include(p => p.Comments); 
         
            return View(posts.ToList());
          
        }

        public ActionResult Search(string query)
        {

            var posts = db.Posts.Include(p => p.Comments);

            var result = (query.Length != 0) ? posts
                .AsQueryable()
                .Where(p => p.Title.ToLower().Contains(query.ToLower()))
                .ToList() : posts.ToList();


            return this.PartialView("_PostListReadOnly", result);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}