using Books.Models;
using EvaraStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaraStore.Infrastructure
{
    public class CartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ShoppingCart model = HttpContext.Session.Get<ShoppingCart>("Cart");
            CartViewModel cart;

            if (model == null)
            {
                cart = null;
            }
            else
            {
                cart = new CartViewModel
                {
                    NumberOfItems = model.lstItems.Sum(x => x.Qty)
                };
            }

            return View(cart);
        }
    }
}
