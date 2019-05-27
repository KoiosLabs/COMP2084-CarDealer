using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Comp2084_CarDealer.Models
{
    public class CarDBInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed (ApplicationDbContext context)
        {
            CarType Sedan = new CarType
            {
                Name = "Sedan",
                NumberOfSeats = 4
            };
            CarType Cabriolet = new CarType
            {
                Name = "Cabriolet",
                NumberOfSeats = 2
            };

            Car Brz = new Car()
            {
                Make = "Subaru",
                Model = "BRZ",
                Price = 40000,
                TypeOfCar = Cabriolet
            };

            Car ThreeSeries = new Car()
            {
                Make = "BMW",
                Model = "335",
                Price = 75000,
                TypeOfCar = Sedan
            };

            context.CarTypes.Add(Sedan);
            context.CarTypes.Add(Cabriolet);
            context.Cars.Add(Brz);
            context.Cars.Add(ThreeSeries);

            base.Seed(context);
        }
    }
}