using Assignment_ShoppipngCart.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_ShoppipngCart.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            ViewBag.HeaderText = "Welcome to the Halloween Store";
            ViewData["FooterText"] = "Where every day is Halloween!";
            return View();
        }

        [HttpGet]
        public ViewResult Contact()
        {
            /*CREATE A ContactViewModel OBJECT call model  model
            ____________________________________________________
            //Pass model to View
            _________________________________*/
            ContactViewModel model = new ContactViewModel();

            return View(model);
        }
    }
}
