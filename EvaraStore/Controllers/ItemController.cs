using EvaraStore.Bl;
using Microsoft.AspNetCore.Mvc;
using System;
using EvaraStore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Books.Models;
using Microsoft.AspNetCore.Identity;

namespace EvaraStore.Controllers
{
    public class ItemController : Controller
    {
        // UserManager & Dependecy Injection
        private readonly UserManager<AppUser> userManager;
        IItemService ItemService;
        IRateService IrateService;
        public ItemController(UserManager<AppUser> userManager, IItemService _Item, IRateService _rate)
        {
            this.userManager = userManager;
            ItemService = _Item;
            IrateService = _rate;
        }

        // Veiw Single Item By Id
        public IActionResult SingleItem(int id)
        {
            SinglePageModel model = new SinglePageModel();
            model.Item = ItemService.GetById(id);

            // Calculate Total Rate Such(85%)
            int resultRate = 0;
            int totalRate = IrateService.GetById(id) * 100;
            int countRate = model.Item.TbRate.Count * 5;
            if (countRate > 0)
                resultRate = totalRate / countRate;

            TempData["TotalRate"] = resultRate.ToString();

            decimal price = model.Item.OldPrice;
            var cat = model.Item.Category.CategoryId;
            int itemId = model.Item.ItemId;
            model.LstRelatedItems = ItemService.GetRelatedItems(price, cat, itemId);

            return View(model);
        }

        // Add To Cart Method
        public IActionResult AddToCart(int id)
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
            else
            {
                model.lstItems.Add(new ShoppingCartItem()
                {
                    ItemId = item.ItemId,
                    ItemName = item.ItemName,
                    ImageName = item.TbImages.FirstOrDefault().ImageName,
                    Price = item.OldPrice,
                    Qty = 1,
                    Stock = item.Stock,
                    Total = item.OldPrice
                });
            }

            model.total = model.lstItems.Sum(a => a.Total);

            HttpContext.Session.Set("Cart", model);

            if (HttpContext.Request.Headers["X-Requested-With"] != "XMLHttpRequest")
                return RedirectToAction("Index");

            return ViewComponent("Cart");
          
        }

        // Rating Form
        [HttpPost]
        public async Task<ActionResult> Rating(TbRate rate)
        {
            AppUser appUser = await userManager.GetUserAsync(HttpContext.User);
            rate.UserId = appUser.Id;
            rate.UserName = appUser.UserName;
            rate.CreationDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                IrateService.Add(rate);
                TempData["Success"] = "Add Your Rating Successfully..";
                return Redirect("~/Item/SingleItem/" + rate.ItemId);
            }
            else
            {
                TempData["Errors"] = "Name should be of minimum 8 and maximum 100 characters, Please Try Again..";
                return Redirect("~/Item/SingleItem/" + rate.ItemId);
            }
        }

    }
}
