using Assignment_LOGIN.Models;
using Assignment_LOGIN.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_LOGIN.Controllers
{
    public class OrderController : Controller
    {
        HALLOWEENEntities ord = new HALLOWEENEntities();

        private List<CartViewModel> listOfCart = new List<CartViewModel>();


        [HttpGet]
        public ActionResult Order()
        {

            return View(ord.Products.ToList());
        }
        [HttpPost]

        public JsonResult Order(string itemId)
        {
            CartViewModel obj = new CartViewModel();
            Product prod = ord.Products.Single(model => model.ProductID.ToString() == itemId);
            if (Session["CartCounter"] != null)
            {
                listOfCart = Session["CartItem"] as List<CartViewModel>;
            }

            if (listOfCart.Any(model => model.ProductID == itemId))
            {
                obj = listOfCart.Single(model => model.ProductID == itemId);
                obj.Quantity = obj.Quantity + 1;
                obj.Total = obj.Quantity * obj.UnitPrice;

            }
            else
            {
                obj.ProductID = itemId;
                obj.Name = prod.Name;
                obj.ImageFile = prod.ImageFile;
                obj.ShortDescription = prod.ShortDescription;
                obj.LongDescription = prod.LongDescription;
                obj.UnitPrice = prod.UnitPrice;
                obj.Total = obj.UnitPrice;
                obj.Quantity = 1;
                listOfCart.Add(obj);
            }
            Session["CartCounter"] = listOfCart.Count;
            Session["CartItem"] = listOfCart;

            return Json(data: new { Success = true, Counter = listOfCart.Count }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Cart()
        {
            listOfCart = Session["CartItem"] as List<CartViewModel>;
            return View(listOfCart);

        }


    }
}