using AGDFiteness4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGDFiteness4.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }
}