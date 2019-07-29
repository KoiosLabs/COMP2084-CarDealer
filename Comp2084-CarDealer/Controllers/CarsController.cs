using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Comp2084_CarDealer.Models;

namespace Comp2084_CarDealer.Controllers
{
    public class CarsController : Controller
    {

        ICarDAL DAL;
        public CarsController(ICarDAL DAL)
        {
            this.DAL = DAL;
        }

        [Route("cars/list")]
        // GET: Cars
        public ActionResult Index()
        {
            var cars = DAL.GetAllCars();
            return View(cars.ToList());
        }

        //[Route("cars/details/{name}")]
        //public String Details(String name)
        //{
        //    return "Car name: " + name;
        //}

        [Route("cars/details/{id:int=1}")]
        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = DAL.FindById(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        [Authorize(Roles ="Admin")]
        // GET: Cars/Create
        public ActionResult Create()
        {
            ViewBag.CarTypeId = new SelectList(DAL.GetCarTypes(), "id", "Name");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Model,Make,Price,CarTypeId")] Car car)
        {
            if (ModelState.IsValid)
            {
                DAL.SaveNewCar(car);
                return RedirectToAction("Index");
            }

            ViewBag.CarTypeId = new SelectList(DAL.GetCarTypes(), "id", "Name", car.CarTypeId);
            return View(car);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = DAL.FindById(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarTypeId = new SelectList(DAL.GetCarTypes(), "id", "Name", car.CarTypeId);
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Model,Make,Price,CarTypeId")] Car car)
        {
            if (ModelState.IsValid)
            {
                DAL.UpdateCar(car);
                return RedirectToAction("Index");
            }
            ViewBag.CarTypeId = new SelectList(DAL.GetCarTypes(), "id", "Name", car.CarTypeId);
            return View(car);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = DAL.FindById(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DAL.DeleteCar(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DAL.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
