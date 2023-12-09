using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiWebAPI.DTO
{
    
    public class CarDTO
    {
        public string Number { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }
        public string TechnicalInspection { get; set; }
        public string DriverId { get; set; }
        public string Color { get; set; }
        public string CarClass { get; set; }
    }
}
