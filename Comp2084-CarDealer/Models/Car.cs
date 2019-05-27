using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Comp2084_CarDealer.Models
{
    public class Car
    {

        public virtual int Id { get; set; }

        public virtual String Model { get; set; }

        public virtual String Make { get; set; }

        [DisplayName("Dealer Book Price")]
        [DataType(DataType.Currency)]
        public virtual Decimal Price { get; set; }

        public virtual int CarTypeId { get; set; }
        public virtual CarType TypeOfCar { get; set; }
    }
}