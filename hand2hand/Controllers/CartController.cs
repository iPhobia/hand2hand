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

      
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }


        //Invokes after submiting checkout form
        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDeatails)
        {
            if(cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry the cart is empty");
            }

            if(ModelState.IsValid)
            {
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(new ShippingDetails());
            }   
        }
    }
}