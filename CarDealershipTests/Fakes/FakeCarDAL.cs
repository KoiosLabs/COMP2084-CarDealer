using Comp2084_CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipTests.Fakes
{
    class FakeCarDAL : ICarDAL
    {

        public int carDeleted = -1;

        public void DeleteCar(int id)
        {
            carDeleted = id;
            return;
        }

        public void Dispose()
        {
            return;
        }

        public Car FindById(int? id)
        {
           if(id==5)
            {
                return new Car()
                {
                    Make = "Toyota",
                    Model = "Crayola",
                    CarTypeId = 2,
                    Price = 19995,
                    Id = 5
                };
           }
            return null;
        }


        public IQueryable<Car> GetAllCars()
        {
            List<Car> cars = new List<Car>();
            cars.Add(new Car()
            {
                Make = "Toyota",
                Model = "Crayola",
                CarTypeId = 2,
                Price = 19995,
                Id = 5
            });
            cars.Add(new Car()
            {
                Make = "Honda",
                Model = "Civic",
                CarTypeId = 2,
                Price = 19996,
                Id = 6
            });
            return cars.AsQueryable();
        }

        public IEnumerable<CarType> GetCarTypes()
        {
            List<CarType> carTypes = new List<CarType>();
            carTypes.Add(new CarType()
            {
                id = 1,
                Name = "Coupe",
                NumberOfSeats = 2
            });
            carTypes.Add(new CarType()
            {
                id = 1,
                Name = "Sedan",
                NumberOfSeats = 4
            });
            return carTypes.AsEnumerable();
        }

        public void SaveNewCar(Car car)
        {
            return;
        }

        public void UpdateCar(Car car)
        {
            return;
        }
    }
}
