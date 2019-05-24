using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hand2hand.Models
{
    //represents set of products added to cart
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public IEnumerable<CartLine> Lines { get { return lineCollection; } }

        public void AddLine(Product product, int quantity)
        {
            CartLine line = lineCollection
                .Where(p => p.Product.Id == product.Id)
                .FirstOrDefault();

            if(line == null)
            {
                lineCollection.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(p => p.Product.Id == product.Id);
        }

        public decimal ComputeValue()
        {
            return lineCollection.Sum(p => p.Product.Price * p.Quantity);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }
    }

    //represents item in Cart
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}