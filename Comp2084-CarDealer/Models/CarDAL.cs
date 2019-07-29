using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Web;

namespace Comp2084_CarDealer.Models
{
    public class CarDAL : ICarDAL
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IQueryable<Car> GetAllCars()
        {
            return db.Cars.Include(c => c.TypeOfCar);
        }

        public Car FindById(int? id)
        {
           return db.Cars.Find(id);
        }
        public IEnumerable<CarType> GetCarTypes()
        {
            return db.CarTypes;
        }
        public void SaveNewCar(Car car)
        {
            db.Cars.Add(car);
            db.SaveChanges();
        }

        public void UpdateCar(Car car)
        {
            db.Entry(car).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteCar(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}