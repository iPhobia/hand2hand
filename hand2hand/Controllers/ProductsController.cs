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
        private ProductContext db = new ProductContext();
        private int pageSize = 3; 

        // GET: Products
        public ActionResult Index(string category, int page = 1)
        {
            ProductsListVIewModel model = new ProductsListVIewModel
            {
                Products = db.Products
                .Where(b => category == null || b.Category == category)
                .OrderBy(product => product.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    TotalItems = category == null ?
                                   db.Products.Count() :
                                   db.Products.Where(product => product.Category == category).Count(),
                    ItemsPerPage = pageSize
                },

                CurrentCategory = category
            };

            return View(model);
        }
    }
}