using AGDFiteness4.Abstract;
using AGDFiteness4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AGDFiteness4.Concrete
{
    public class SpareProductRepository : IProductRepository
    {
        private Entities context; 
        //private SpareContext context;

        public SpareProductRepository()
        {
            context = new Entities();
        }

        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }

        public IEnumerable<CategoryTBL> CategoryTBLs
        { 
            get { return context.CategoryTBLs; } 
        }

        public Product Find(int? ProductID)
        {
            return context.Products.Find(ProductID);
        }

        public void Add(Product product)
        {
            context.Products.Add(product);
        }

        public void Remove(Product product)
        {
            context.Products.Remove(product);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Entry(Product product)
        {
            context.Entry(product).State = EntityState.Modified;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}