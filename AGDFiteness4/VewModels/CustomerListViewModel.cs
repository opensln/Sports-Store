using System;
using AGDFiteness4.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGDFiteness4.VewModels
{
    public class CustomerListViewModel
    {
        public IEnumerable<Product> Products { get; set; }   
        public PagingInfo PagingInfo { get; internal set; }
        public string CurrentCategory { get; set; }
    }
}