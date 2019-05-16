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

        public ViewResult Index(string returnUrl)
        {
            return View(new CartViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        //???
        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }

        //
        public RedirectToRouteResult AddToCart(int Id, string returnUrl)
        {
            Product product = db.Products
                .FirstOrDefault(p => p.Id == Id );

            if(product != null)
            {
                GetCart().AddLine(product, 1);
            }

            return RedirectToAction(actionName: "Index", controllerName: "Cart", routeValues: new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(int Id, string returnUrl)
        {
            Product product = db.Products
                .FirstOrDefault(p => p.Id == Id);

            if (product != null)
            {
                GetCart().RemoveLine(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }
    }
}