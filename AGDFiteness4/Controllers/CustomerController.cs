using AGDFiteness4.Abstract;
using AGDFiteness4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using AGDFiteness4.VewModels;

namespace AGDFiteness4.Controllers
{
    public class CustomerController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 6; //Initialize and set.

        //-----------------------------db context------------------------

        private Entities db = new Entities();

        //-----------------------------End db context--------------------

        public CustomerController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        public ViewResult CustomerLister()
        {
            return View(repository.Products);
        }
        //--------------------------------End Repository Section----------------------







        //------------------------Straight From ADO-Entity------------------Working
        
        //GET: Customer
        public ViewResult CustomerList(string category, int page = 1)
        {
            //var products = db.Products.Include(p => p.CategoryTBL);
            CustomerListViewModel model = new CustomerListViewModel
            {
                Products = db.Products
                .Where(p => category == null || p.CategoryTBL.CategoryName == category)
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? db.Products.Count() : db.Products.
                    Where(e => e.CategoryTBL.CategoryName == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
            
        }

        //-------------------------Details--------------------------

        // GET: Mobiles/Details/5
        public ActionResult Details(int? ProductID)
        {
            //    if (ProductID == null)
            //    {
            //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //    }
            Product SingleProduct = db.Products.Find(ProductID);
            //    if (SingleProduct == null)
            //    {
            //        return HttpNotFound();
            //    }
            return View(SingleProduct);
            //  return View();
        }
    }
}