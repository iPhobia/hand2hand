using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hand2hand.Models;

namespace hand2hand.Controllers
{
    public class ProductsController : Controller
    {
        ProductContext db = new ProductContext();

        // GET: Products
        public ActionResult Index()
        { 
            return View(db.Products);
        }
    }
}