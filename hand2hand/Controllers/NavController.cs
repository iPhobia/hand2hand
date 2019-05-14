using hand2hand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hand2hand.Controllers
{
    public class NavController : Controller
    {
        private ProductContext db = new ProductContext();

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = db.Products
                .Select(product => product.Category)
                .Distinct()
                .OrderBy(x => x);

            return PartialView(categories);
        }
    }
}