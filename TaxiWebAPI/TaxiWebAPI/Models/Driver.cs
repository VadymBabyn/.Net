using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiWebAPI.Model
{
    public class Driver
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _licenseNumber;
        private string _address;
        private string _phoneNumber;
        private string _carNumber;
        private string _taxiServicePhoneNumber;

        public Driver()
        {
            _id = 0;
            _firstName = "";
            _lastName = "";
            _licenseNumber = "";
            _address = "";
            _phoneNumber = "";
            _carNumber = "";
            _taxiServicePhoneNumber = "";
        }

        public Driver(string firstName, string lastName, string licenseNumber, string address, string phoneNumber, string carNumber, string taxiServicePhoneNumber)
        {
            _firstName = firstName;
            _lastName = lastName;
            _licenseNumber = licenseNumber;
            _address = address;
            _phoneNumber = phoneNumber;
            _carNumber = carNumber;
            _taxiServicePhoneNumber = taxiServicePhoneNumber;
        }
        public Driver(string firstName, string lastName, string address, string phoneNumber, string taxiServicePhoneNumber)
        {
            _firstName = firstName;
            _lastName = lastName;
            _address = address;
            _phoneNumber = phoneNumber;
            _taxiServicePhoneNumber = taxiServicePhoneNumber;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string LicenseNumber
        {
            get { return _licenseNumber; }
            set { _licenseNumber = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        public string CarNumber
        {
            get { return _carNumber; }
            set { _carNumber = value; }
        }

        public string TaxiServicePhoneNumber
        {
            get { return _taxiServicePhoneNumber; }
            set { _taxiServicePhoneNumber = value; }
        }
    }
}
