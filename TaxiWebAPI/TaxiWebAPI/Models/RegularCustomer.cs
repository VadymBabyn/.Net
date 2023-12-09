using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiWebAPI.Model
{
    public class RegularCustomer
    {
        private int _customerId;
        private string _firstName;
        private string _lastName;
        private string _address;
        private string _phoneNumber;
        public List<Receipt> Receipts { get; set; } = new List<Receipt>(); // Ініціалізуємо список Receipts в конструкторі
        public RegularCustomer()
        {
            _customerId = 0;
            _firstName = "";
            _lastName = "";
            _address = "";
            _phoneNumber = "";
        }

        public RegularCustomer(string firstName, string lastName, string address, string phoneNumber)
        {
            _firstName = firstName;
            _lastName = lastName;
            _address = address;
            _phoneNumber = phoneNumber;
        }

        public int CustomerId
        {
            get { return _customerId; }
            set { _customerId = value; }
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
    }
}
