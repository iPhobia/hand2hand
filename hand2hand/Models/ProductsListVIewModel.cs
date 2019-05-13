using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hand2hand.Models
{
    public class ProductsListVIewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}