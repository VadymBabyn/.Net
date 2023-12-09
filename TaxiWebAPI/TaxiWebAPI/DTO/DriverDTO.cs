using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TaxiWebAPI.DTO
{
    public class DriverDTO
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _licenseNumber;
        private string _address;
        private string _phoneNumber;
        private string _carNumber;
        private string _taxiServicePhoneNumber;
        public DriverDTO() 
        {

        }
        public DriverDTO(int id, string firstName, string lastName, string licenseNumber, string address, string phoneNumber, string carNumber, string taxiServicePhoneNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            LicenseNumber = licenseNumber;
            Address = address;
            PhoneNumber = phoneNumber;
            CarNumber = carNumber;
            TaxiServicePhoneNumber = taxiServicePhoneNumber;           
        }
        public DriverDTO(int id, string firstName, string lastName, string address, string phoneNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;          
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
