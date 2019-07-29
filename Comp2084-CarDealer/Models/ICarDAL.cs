using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Comp2084_CarDealer.Models
{
    public interface ICarDAL
    {
        void DeleteCar(int id);
        void Dispose();
        Car FindById(int? id);
        IQueryable<Car> GetAllCars();
        IEnumerable<CarType> GetCarTypes();
        void SaveNewCar(Car car);
        void UpdateCar(Car car);
    }
}