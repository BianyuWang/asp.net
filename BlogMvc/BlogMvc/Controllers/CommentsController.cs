using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BlogMvc.Models;
using Microsoft.AspNet.Identity;

namespace BlogMvc.Controllers
{
   
    public class CommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
      

        // GET: Comments
        [Authorize]
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);

            var comments = db.Comments.Include(c => c.Post).Where(c=>c.UseFullName==currentUser.FullName);
            return View(comments.ToList());
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comments/Create
        [Authorize]
        public ActionResult Create(int? id)
        {
           ViewBag.PostId = new SelectList(db.Posts, "Id", "Title",id);

          /*  Post selected = db.Posts.Where(p => p.Id == id).First();

            foreach (var item in ViewBag.PostId)
            {
                if (item.Value == selected.Title)
                {
                    item.Selected = true;
                    break;
                }
            }*/

            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Content,CreatedOn,UpdatedOn,UseFullName,PostId,IsPublished")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                string currentUserId = User.Identity.GetUserId();
                ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
                comment.UseFullName = currentUser.FullName;

                if (User.IsInRole("CanManage"))
                    comment.IsPublished = true;

                db.Comments.Add(comment);
                db.SaveChanges();

                  return RedirectToAction("Details","Posts",new { Id=comment.PostId});
            }

            ViewBag.PostId = new SelectList(db.Posts, "Id", "Title", comment.PostId);
            return View(comment);
        }

        [Authorize]// GET: Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Title", comment.PostId);
            return View(comment);
        }

       
        [Authorize(Roles = RoleName.CanManage)]
        public ActionResult ApproveCommentByAdmin(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment Comment = db.Comments.Where(c => c.Id == id).FirstOrDefault();
            if (Comment == null)
            {
                return HttpNotFound();
            }

            Comment.IsPublished = true;
           
            db.Entry(Comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details","Posts", new { Id= Comment.PostId});
           
          
        }
        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Content,CreatedOn,UpdatedOn,UseFullName,PostId,IsPublished")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("CanManage"))
                    comment.IsPublished = true;
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Title", comment.PostId);
            return View(comment);
        }

        // GET: Comments/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Comment comment = db.Comments.Find(id);

            int postId = comment.PostId;
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Details","Posts", new { Id= postId});
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
