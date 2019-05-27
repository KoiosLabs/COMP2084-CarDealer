using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Comp2084_CarDealer.Models
{
    public class CarType
    {
        public virtual int id { get; set; }
        
        public virtual String Name { get; set; }
        public virtual int NumberOfSeats { get; set; }
        public virtual List<Car> cars { get; set; }
    }
}