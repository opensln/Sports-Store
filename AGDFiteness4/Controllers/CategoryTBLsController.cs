using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AGDFiteness4.Models;

namespace AGDFiteness4.Controllers
{
    public class CategoryTBLsController : Controller
    {
        private Entities db = new Entities();

        // GET: CategoryTBLs
        public ActionResult Index()
        {
            return View(db.CategoryTBLs.ToList());
        }

        // GET: CategoryTBLs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryTBL categoryTBL = db.CategoryTBLs.Find(id);
            if (categoryTBL == null)
            {
                return HttpNotFound();
            }
            return View(categoryTBL);
        }

        // GET: CategoryTBLs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryTBLs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CatID,CategoryName")] CategoryTBL categoryTBL)
        {
            if (ModelState.IsValid)
            {
                db.CategoryTBLs.Add(categoryTBL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoryTBL);
        }

        // GET: CategoryTBLs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryTBL categoryTBL = db.CategoryTBLs.Find(id);
            if (categoryTBL == null)
            {
                return HttpNotFound();
            }
            return View(categoryTBL);
        }

        // POST: CategoryTBLs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CatID,CategoryName")] CategoryTBL categoryTBL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoryTBL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoryTBL);
        }

        // GET: CategoryTBLs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryTBL categoryTBL = db.CategoryTBLs.Find(id);
            if (categoryTBL == null)
            {
                return HttpNotFound();
            }
            return View(categoryTBL);
        }

        // POST: CategoryTBLs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoryTBL categoryTBL = db.CategoryTBLs.Find(id);
            db.CategoryTBLs.Remove(categoryTBL);
            db.SaveChanges();
            return RedirectToAction("Index");
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
