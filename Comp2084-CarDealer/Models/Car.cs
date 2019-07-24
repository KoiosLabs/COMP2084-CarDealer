using Comp2084_CarDealer.Validators;
using Newtonsoft.Json;
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
        //We need a primary key on every table.
        public virtual int Id { get; set; }

        public virtual String Model { get; set; }
        

        [MaxWords(3)]
        public virtual String Make { get; set; }

        [DisplayName("Dealer Book Price")]
        [DataType(DataType.Currency)]
        [Required]
        [Range(10000,49999)]
        public virtual Decimal Price { get; set; }

        public virtual int CarTypeId { get; set; }
        [JsonIgnore]
        public virtual CarType TypeOfCar { get; set; }
    }
}