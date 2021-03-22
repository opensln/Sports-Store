using AGDFiteness4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AGDFiteness4.Controllers
{
    public class NavController : Controller
    {
        private Entities db = new Entities();
    

        public PartialViewResult CatMenu(string category = null)
        {

            ViewBag.SelectedCategory = category;     

            IEnumerable<string> MenuCategories = db.CategoryTBLs

               .Select(x => x.CategoryName)
                .Distinct()
                .OrderBy(x => x);

            //converted MenuCategory into a type<string> ready for passing?

            return PartialView(MenuCategories);
        }
    }
}