using AGDFiteness4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AGDFiteness4.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }

        IEnumerable<CategoryTBL> CategoryTBLs { get; }

        void Add(Product product);

        void Remove(Product product);

        void SaveChanges();

        void Entry(Product product);

        Product Find(int? ProductID);

        void Dispose();
    }
}