using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Basic_level2_agan.Models;

namespace Basic_level2_agan.Controllers
{
    public class BlogController : Controller
    {
        private BlogDBContext db = new BlogDBContext();

        // GET: /Blog/
        /// <summary>
        /// Index
        /// </summary>
        /// <returns>view of List of Blog</returns>
        public ActionResult Index()
        {
            return View(db.Blogs.ToList());
        }

        // GET: /Blog/Details/5
        /// <summary>
        /// Detail by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: /Blog/Create
        
        /// <summary>
        /// create view
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();          
        }

        // POST: /Blog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for       
        /// <summary>
        /// create view and add Blog
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,tin,loai,trangThai,viTri,ngayPublic,motangan,chitiet")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }
        // GET: /Blog/Edit/5
        /// <summary>
        /// edit blog
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: /Blog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for    
        /// <summary>
        /// edit
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,tin,loai,trangThai,viTri,ngayPublic")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blog).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: /Blog/Delete/5
        /// <summary>
        /// delete blog
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Blog blog = db.Blogs.Find(id);
        //    if (blog == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(blog);


        //}

        
        public RedirectToRouteResult Delete2(int? id)
        {
            Blog blog = db.Blogs.Find(id);
           
            db.Blogs.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: /Blog/Delete/5
        /// <summary>
        /// delete by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// search by id
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public ActionResult Search(string searchString)
        {
            var blogs = from m in db.Blogs select m;
            if(!String.IsNullOrEmpty(searchString))
            {
                blogs = blogs.Where(s => s.tin.Contains(searchString));
            }
            return View(blogs);
        }
     
        /// <summary>
        /// override void dispose
        /// </summary>
        /// <param name="disposing"></param>
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
