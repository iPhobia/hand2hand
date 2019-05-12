using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hand2hand.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        //path to img
        public string Url { get; set; }
    }
}