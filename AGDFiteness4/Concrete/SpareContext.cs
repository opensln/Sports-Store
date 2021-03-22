using AGDFiteness4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AGDFiteness4.Concrete
{
    public class SpareContext : DbContext
    {
        public DbSet<Product> Products {get; set;}
        public DbSet<CategoryTBL> CategoryTBLs { get; set; }
    }
}