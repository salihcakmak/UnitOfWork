using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication37.DAL;
using WebApplication37.DAL.UnitOfWork;
using WebApplication37.Models;

namespace WebApplication37.Controllers
{
    
    [Authorize]
    public class EntryController : Controller
    {

        
        BlogContext db = new BlogContext();
        // GET: Entry
        public ActionResult Index()
        {
            List<Entry> entries = db.Entries.ToList();

            return View(entries);
        }

        // GET: Entry/Create
        public ActionResult Create()
        {
           
           ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Entry/Create
        [HttpPost]
        public ActionResult Create(Entry ent)
        {
            try
            {
                UnitofWork uow = new UnitofWork(db);
                uow.GetRepository<Entry>().Add(ent);
                uow.SaveChanges();

                //db.Entries.Add(ent);
                //db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Entry/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            Entry ent = db.Entries.Find(id);

            return View(ent);
        }

        // POST: Entry/Edit/5
        [HttpPost]
        public ActionResult Edit(Entry ent)
        {
            try
            {
                db.Entry(ent).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Entry/Delete/5
        public ActionResult Delete(int id)
        {
            Entry ent = new Entry();
            ent = db.Entries.Where(x => x.Id == id).FirstOrDefault();
            return View(ent);
        }

        // POST: Entry/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            UnitofWork uow = new UnitofWork(db);
            
            Entry ent = db.Entries.Where(x => x.Id == id).FirstOrDefault();
            uow.GetRepository<Entry>().Delete(ent);
            uow.SaveChanges();
            //db.Entries.Remove(ent);
            //db.SaveChanges();
            return RedirectToAction("Index", "Entry");
        }
    }
}
