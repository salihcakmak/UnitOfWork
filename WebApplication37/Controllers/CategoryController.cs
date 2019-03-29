using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication37.DAL;
using WebApplication37.Models;

namespace WebApplication37.Controllers
{
    [Authorize (Roles ="Admin")]
    public class CategoryController : Controller
    {
        BlogContext db = new BlogContext();
        // GET: Category
        public ActionResult Index()
        {
            List<Category> categories = db.Categories.ToList();
            return View(categories);
        }
       
       
        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category c)
        {
            try
            {
                db.Categories.Add(c);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            Category category = db.Categories.Find(id);
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Category c)
        {
            try
            {
                db.Entry(c).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            Category c = new Category();
            using (BlogContext cdb=new BlogContext ())
            {
                c = cdb.Categories.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(c);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using (BlogContext dbb=new BlogContext ())
            {
                Category category = dbb.Categories.Where(x => x.Id == id).FirstOrDefault();
                dbb.Categories.Remove(category);
                dbb.SaveChanges();

            }
            return RedirectToAction("Index", "Category");
        }
    }
}
