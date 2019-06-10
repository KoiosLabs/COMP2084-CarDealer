using Comp2084_CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Comp2084_CarDealer.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
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


        public ActionResult Special()
        {
            var SaleCar = GetSpecial();
            return PartialView("_Special", SaleCar);
        }
        // Select an album and discount it by 50%        
        private Car GetSpecial()
        {
            var SaleCar = db.Cars
                .OrderBy(a => System.Guid.NewGuid())
                .First();
            SaleCar.Price *= 0.5m;
            return SaleCar;
        }

        public ActionResult CarSearch(string q)
        {
            var cars = GetCars(q);
            return PartialView(cars);
        }

        public ActionResult QuickSearch(string term)
        {
            var cars = GetCars(term).Select(a => new { value = a.Make +" "+a.Model });
            return Json(cars, JsonRequestBehavior.AllowGet);
        }


        private List<Car> GetCars(string searchString)
        {
            return db.Cars.Where(a => a.Model.Contains(searchString) || a.Make.Contains(searchString)).ToList();
        }



        [Authorize]
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