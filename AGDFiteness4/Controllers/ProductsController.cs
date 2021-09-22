using System;
using AGDFiteness4.Abstract;
using AGDFiteness4.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using AGDFiteness4.VewModels;
using System.Net;
using System.IO;
using System.Data;

namespace AGDFiteness4.Controllers
{
    public class ProductsController : Controller
    {
        //private Entities db;
        private IProductRepository repository;

        public ProductsController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        // GET: Products
        public ActionResult Index()
        {
            //var products = repository.Products.Include(p => p.CategoryTBL);

            var products = repository.Products;

            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repository.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(repository.CategoryTBLs, "CatID", "CategoryName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,ProductPrice,Image,CategoryID,Instock, ImageFile")] Product product)
        {
            if (ModelState.IsValid)
            {
                string imagename = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                string extension = Path.GetExtension(product.ImageFile.FileName);
                imagename = imagename + extension;
                product.Image = imagename;


                imagename = Path.Combine(Server.MapPath("~/Content/Images/ProductImages"), imagename);
                product.ImageFile.SaveAs(imagename);
                                                                                                    
                repository.Add(product);
                repository.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(repository.CategoryTBLs, "CatID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repository.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(repository.CategoryTBLs, "CatID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,ProductPrice,Image,CategoryID,Instock")] Product product)
        {
            if (ModelState.IsValid)
            {
                repository.Entry(product); 
                repository.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(repository.CategoryTBLs, "CatID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repository.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = repository.Find(id);
            repository.Remove(product);
            repository.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
            }
            base.Dispose(disposing);
        }   
    }
}
