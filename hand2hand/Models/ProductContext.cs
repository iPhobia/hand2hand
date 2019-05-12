using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace hand2hand.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("ProductsDb")
        { }

       public DbSet<Product> Products { get; set; }
    }
}