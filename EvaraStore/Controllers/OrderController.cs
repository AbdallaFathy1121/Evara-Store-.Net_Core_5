using Books.Models;
using EvaraStore.Bl;
using EvaraStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaraStore.Controllers
{
    public class OrderController : Controller
    {

        IItemService ItemService;
        public OrderController(IItemService _Item)
        {
            ItemService = _Item;
        }

        // View Cart
        public IActionResult Cart()
        {
            ShoppingCart model = HttpContext.Session.Get<ShoppingCart>("Cart");

            return View(model);
        }

        // Method Increment Qty in Cart
        public IActionResult Increment(int id)
        {
            ShoppingCart model = HttpContext.Session.Get<ShoppingCart>("Cart");

            if (model == null)
                model = new ShoppingCart();

            TbItem item = ItemService.GetById(id);

            // Method When Item Already in ShoppingCart, Not Add NewItem But Increase Item_Qty only
            ShoppingCartItem Shopping = model.lstItems.Where(a => a.ItemId == id).FirstOrDefault();
            if (Shopping != null && Shopping.Qty != item.Stock)
            {
                Shopping.Qty++;
                Shopping.Total = Shopping.Qty * Shopping.Price;
            }
            model.total = model.lstItems.Sum(a => a.Total);

            HttpContext.Session.Set("Cart", model);


            return Redirect(Request.Headers["Referer"].ToString());
        }
        
        // Method Decrement Qty in Cart
        public IActionResult Decrement(int id)
        {
            ShoppingCart model = HttpContext.Session.Get<ShoppingCart>("Cart");

            if (model == null)
                model = new ShoppingCart();

            TbItem item = ItemService.GetById(id);

            // Method When Item Already in ShoppingCart, Not Add NewItem But Increase Item_Qty only
            ShoppingCartItem Shopping = model.lstItems.Where(a => a.ItemId == id).FirstOrDefault();
            if (Shopping != null && Shopping.Qty != 1)
            {
                Shopping.Qty--;
                Shopping.Total = Shopping.Qty * Shopping.Price;
            }
            else
            {
                model.lstItems.Remove(model.lstItems.Where(a => a.ItemId == id).FirstOrDefault());
            }
            model.total = model.lstItems.Sum(a => a.Total);

            HttpContext.Session.Set("Cart", model);


            return Redirect(Request.Headers["Referer"].ToString());
        }

        // Method Remove Item From Cart
        public IActionResult RemoveItem(int id)
        {
            ShoppingCart model = HttpContext.Session.Get<ShoppingCart>("Cart");
            model.lstItems.Remove(model.lstItems.Where(a => a.ItemId == id).FirstOrDefault());
            model.total = model.lstItems.Sum(a => a.Total);
            HttpContext.Session.Set("Cart", model);
            return Redirect(Request.Headers["Referer"].ToString());
        }

        // Method Remove All Items in Cart
        public IActionResult RemoveAll()
        {
            ShoppingCart model = HttpContext.Session.Get<ShoppingCart>("Cart");
            model = null;
            TempData["Clear"] = "Delete All Products Successfully...";
            HttpContext.Session.Set("Cart", model);
            return Redirect(Request.Headers["Referer"].ToString());
        }

    }
}
