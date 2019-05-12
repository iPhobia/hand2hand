using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace hand2hand.Models
{
    public class ProductsDbInitializer : DropCreateDatabaseIfModelChanges<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            context.Products.Add(new Product
            {
                Name = "Trousers",
                Price = 20,
                Category = "Clothes",
                Description = "Brand new trousers",
                Url = "/img/trous.jpg"
            }
            );
            context.Products.Add(new Product
            {
                Name = "Phone",
                Price = 50,
                Category = "Gadgets",
                Description = "1 year in use. Good condition.",
                Url = "/img/phone.jpg"
            }
            );
            context.Products.Add(new Product
            {
                Name = "Book",
                Price = 25,
                Category = "Education",
                Description = "L. Tolstoi 'War and Peace'. Good condition ",
                Url = "/img/book.jpg"
            }
            );

            base.Seed(context);
        }
    }
}