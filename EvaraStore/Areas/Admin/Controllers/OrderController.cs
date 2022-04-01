using EvaraStore.Bl;
using EvaraStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ZXing;

namespace EvaraStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class OrderController : Controller
    {
        // Dependency Injection
        IOrderService IOrderService;
        public OrderController(IOrderService _order)
        {
            IOrderService = _order;
        }

        // View Orders
        public IActionResult List(string id)
        {
            List<TbOrder> lstOrder = new List<TbOrder>();

            if (id == "Rejected-Orders")
                lstOrder = IOrderService.GetOrderByRejected();
            else if (id == "Pending-Orders")
                lstOrder = IOrderService.GetOrderByProcessing();
            else if (id == "Completed-Orders")
                lstOrder = IOrderService.GetOrderByCompleted();
            else
                lstOrder = IOrderService.GetAll();

            return View(lstOrder);
        }

        // View Rejected Orders
        public IActionResult RejectedOrders()
        {
            List<TbOrder> lstOrder = IOrderService.GetOrderByRejected();

            return View(lstOrder);
        }

        // View Order Invoice
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

        // View Edit Order
        public IActionResult Edit(int id)
        {
            TbOrder order = IOrderService.GetById(id);

            return View(order);
        }

        // Form Edit Order
        [HttpPost]
        public IActionResult Save(TbOrder order)
        {
            var status = Request.Form["status"];
            order.Status = status;

            IOrderService.Edit(order);

            TempData["Update"] = "Order Was Updated Successfully..";
            return RedirectToAction("List");
        }

    
    }
}
