using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hand2hand.Models;

namespace hand2hand.Controllers
{
    public class CartController : Controller
    {
        private ProductContext db = new ProductContext();

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        //
        public RedirectToRouteResult AddToCart(Cart cart, int Id, string returnUrl)
        {
            Product product = db.Products
                .FirstOrDefault(p => p.Id == Id );

            if(product != null)
            {
                cart.AddLine(product, 1);
            }

            return RedirectToAction(actionName: "Index", controllerName: "Cart", routeValues: new { returnUrl });
        }
         
        public RedirectToRouteResult RemoveFromCart(Cart cart, int Id, string returnUrl)
        {
            Product product = db.Products
                .FirstOrDefault(p => p.Id == Id);

            if (product != null)
            {
                cart.RemoveLine(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        //checkout
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
    }
}