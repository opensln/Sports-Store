using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AGDFiteness4.Models;

namespace AGDFiteness4.VewModels
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}