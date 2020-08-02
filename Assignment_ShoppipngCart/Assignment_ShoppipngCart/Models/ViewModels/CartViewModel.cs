using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_ShoppipngCart.Models.ViewModels
{
    public class CartViewModel
    {

        public string ProductID { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public decimal Total { get; set; }

        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string CategoryID { get; set; }
        public string ImageFile { get; set; }
        public decimal UnitPrice { get; set; }
    }
}