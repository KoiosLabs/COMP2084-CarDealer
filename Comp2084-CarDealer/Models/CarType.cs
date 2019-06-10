using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Comp2084_CarDealer.Models
{
    public class CarType
    {
        public virtual int id { get; set; }
        
        [Required]
        [DisplayName("Car Type")]
        public virtual String Name { get; set; }
        [Range(1,50,ErrorMessage = "You dolt, {0} must be between 1 and 50")]
        public virtual int NumberOfSeats { get; set; }
        public virtual List<Car> cars { get; set; }
    }
}