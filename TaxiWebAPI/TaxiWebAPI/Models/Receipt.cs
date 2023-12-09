using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiWebAPI.Model
{
    public class Receipt
    {
        private int _receiptNumber;
        private int _driverId;
        private string _pickupAddress;
        private string _destinationAddress;
        private float _distance;
        private int _regularCustomerId;
        private decimal _paymentAmount;
        private string _usersPassportSerial;
        private DateTime _openReceiptDate;

        public Receipt()
        {
            _receiptNumber = 0;
            _driverId = 0;
            _pickupAddress = "";
            _destinationAddress = "";
            _distance = 0.0f;
            _regularCustomerId = 0;
            _paymentAmount = 0;
            _usersPassportSerial = "";
            _openReceiptDate = DateTime.MinValue;
        }

        public Receipt(int driverId, string pickupAddress, string destinationAddress, float distance, int regularCustomerId, decimal paymentAmount, string usersPassportSerial, DateTime openReceiptDate)
        {
            _driverId = driverId;
            _pickupAddress = pickupAddress;
            _destinationAddress = destinationAddress;
            _distance = distance;
            _regularCustomerId = regularCustomerId;
            _paymentAmount = paymentAmount;
            _usersPassportSerial = usersPassportSerial;
            _openReceiptDate = openReceiptDate;
        }

        public int ReceiptNumber
        {
            get { return _receiptNumber; }
            set { _receiptNumber = value; }
        }

        public int DriverId
        {
            get { return _driverId; }
            set { _driverId = value; }
        }

        public string PickupAddress
        {
            get { return _pickupAddress; }
            set { _pickupAddress = value; }
        }

        public string DestinationAddress
        {
            get { return _destinationAddress; }
            set { _destinationAddress = value; }
        }

        public float Distance
        {
            get { return _distance; }
            set { _distance = value; }
        }

        public int RegularCustomerId
        {
            get { return _regularCustomerId; }
            set { _regularCustomerId = value; }
        }

        public decimal PaymentAmount
        {
            get { return _paymentAmount; }
            set { _paymentAmount = value; }
        }

        public string UsersPassportSerial
        {
            get { return _usersPassportSerial; }
            set { _usersPassportSerial = value; }
        }

        public DateTime OpenReceiptDate
        {
            get { return _openReceiptDate; }
            set { _openReceiptDate = value; }
        }
    }
}
