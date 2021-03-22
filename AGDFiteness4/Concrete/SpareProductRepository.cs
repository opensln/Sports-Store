using AGDFiteness4.Abstract;
using AGDFiteness4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGDFiteness4.Concrete
{
    public class SpareProductRepository : IProductRepository
    {
        private SpareContext context = new SpareContext();
         
        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }

        //--------------Might need to include CategoryTBLs at some stage----------------
    }
}