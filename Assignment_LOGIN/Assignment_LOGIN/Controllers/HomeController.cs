using Assignment_LOGIN.Models;
using Assignment_LOGIN.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_LOGIN.Controllers
{
    public class HomeController : Controller
    {
        HALLOWEENEntities obj = new HALLOWEENEntities();
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

            ContactViewModel model = new ContactViewModel();

            return View(model);
        }
        [HttpGet]
        public ActionResult Signup()
        {
            Login[] logins = obj.Logins.ToArray();
            return View();

        }
        [HttpPost]
        public ActionResult Signup(Login log)
        {
            obj.Logins.Add(log);
            obj.SaveChanges();
            return RedirectToAction("Login");

        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Login( Login log)
        {
            var logins = obj.Logins.Where(x => x.username == log.username && x.password == log.password).FirstOrDefault();
            if(logins == null)
            {
                log.ErrorMessage = "Username or Password is incorrect";


                return View("Login", log);
            }
            else
            {
                Session["userno"] = logins.userno;
                return RedirectToAction("Order", "Order");
            }
            
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }



    }

}