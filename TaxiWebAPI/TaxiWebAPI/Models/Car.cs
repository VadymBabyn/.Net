using Org.BouncyCastle.Asn1.Sec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiWebAPI.Model
{
    public class Car
    {
        private string number;
        private string brand;
        private int year;
        private string Technical_inspection;
        private string pasport_id_Driver;
        private string color;
        private string car_class;

        // Пустий конструктор
        public Car()
        {
            number = "";
            brand = "";
            year = 0;
            Technical_inspection = "";
            pasport_id_Driver = "";
            color = "";
            car_class = "";
        }

        public Car(string carNumber, string carBrand, int carYear, string techInspection, string driverId, string carColor, string carClass)
        {
            number = carNumber;
            brand = carBrand;
            year = carYear;
            Technical_inspection = techInspection;
            pasport_id_Driver = driverId;
            color = carColor;
            car_class = carClass;
        }

        public string Number
        {
            get { return number; }
            set { number = value; }
        }

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }


        public string TechnicalInspection
        {
            get { return Technical_inspection; }
            set { Technical_inspection = value; }
        }

        public string DriverId
        {
            get { return pasport_id_Driver; }
            set { pasport_id_Driver = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public string CarClass
        {
            get { return car_class; }
            set { car_class = value; }
        }
    
    }

}
