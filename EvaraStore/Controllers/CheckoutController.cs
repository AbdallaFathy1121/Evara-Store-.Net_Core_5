using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using EvaraStore.Models;
using Books.Bl;
using Microsoft.AspNetCore.Http;
using System.IO;
using EvaraStore.Bl;
using Books.Models;
using System.Drawing;
using System.Drawing.Imaging;
using ZXing;

namespace EvaraStore.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        // UserManager & Dependecy Injection
        private readonly UserManager<AppUser> userManager;
        IItemService ItemService;
        IBillingService IBillingService;
        IOrderService IOrderService;
        IOrderItemsService IOrderItemsService;
        public CheckoutController(UserManager<AppUser> userManager, IItemService _Item, IBillingService _bill, IOrderService _order,                IOrderItemsService _orderItems)
        {
            this.userManager = userManager;
            ItemService = _Item;
            IBillingService = _bill;
            IOrderService = _order;
            IOrderItemsService = _orderItems;
        }

        // View Checkout Page
        public async Task<IActionResult> Index()
        {
            AppUser appUser = await userManager.GetUserAsync(HttpContext.User);

            CheckoutModel model = new CheckoutModel();
            model.Cart = HttpContext.Session.Get<ShoppingCart>("Cart");
            model.Billing = IBillingService.GetById(appUser.Id);

            return View(model);
        }

        // Form Place Order
        [HttpPost]
        public async Task<ActionResult> PlaceOrder(TbBilling billing)
        {
            AppUser appUser = await userManager.GetUserAsync(HttpContext.User);
            ShoppingCart model = HttpContext.Session.Get<ShoppingCart>("Cart");
            
            // Billing
            billing.UserId = appUser.Id;
            billing.UserName = appUser.UserName;
            billing.UserEmail = appUser.Email;
            if(billing.Id == 0)
                IBillingService.Add(billing);
            else
                IBillingService.Edit(billing);

            // Get TbBilling By UserId
            TbBilling b = IBillingService.GetById(appUser.Id);

            // Start Add New Order
                TbOrder order = new TbOrder();
                order.Date = DateTime.Now;
                order.BillingId = b.Id;
                order.Status = "Processing";
                order.Total = model.total;

                // Create SerialNumber
                Random rnd1 = new Random();
                Random rnd2 = new Random();
                order.SerialNumber = rnd1.Next(100, 1000).ToString() + rnd2.Next(1000, 10000).ToString() + billing.Id.ToString();

                IOrderService.Add(order);
            // End Add New Order


            // Start Add Items in List of OrderItems
                // Get TbOrder by Date
                TbOrder o = IOrderService.GetByDate(order.Date);

                List<TbOrderItems> itemOrder = new List<TbOrderItems>();
                foreach (var m in model.lstItems)
                {
                    itemOrder.Add(new TbOrderItems()
                    {
                        OrderId = o.OrderId,
                        ItemId = m.ItemId,
                        ImageName = m.ImageName,
                        ItemName = m.ItemName,
                        Qty = m.Qty,
                        Price = m.Price
                    });
                }
                IOrderItemsService.Add(itemOrder);
            // Start Add Items in List of OrderItems

            // Clear Cart
            model = null;
            HttpContext.Session.Set("Cart", model);

            return Redirect("~/Checkout/Invoice/" + o.OrderId);
        }

        // View Invoice Page
        public IActionResult Invoice(int id)
        {
            TbOrder order = IOrderService.GetById(id);

            return View(order);
        }

        // Render ImageBarcode
        public ActionResult RenderBarcode(string barcode)
        {
            Image img = null;
            using (var ms = new MemoryStream())
            {
                var writer = new ZXing.BarcodeWriter() { Format = BarcodeFormat.CODE_128 };
                writer.Options.Height = 80;
                writer.Options.Width = 280;
                writer.Options.PureBarcode = true;
                img = writer.Write(barcode);
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return File(ms.ToArray(), "image/jpeg");
            }
        }

    }
}
