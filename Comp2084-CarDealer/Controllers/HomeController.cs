using Comp2084_CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Comp2084_CarDealer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            AboutViewModel avm = new AboutViewModel()
            {
                Title = "About our car dealership",
                Message = "We are a world renowned car dealership with the finest vehicles.",
                NewItem = "This is our new Item variable!"
            };

            return View(avm);
        }
        public ActionResult Support()
        {
            ViewBag.Message = "This is a support page, you can get help here if you need it!";
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}