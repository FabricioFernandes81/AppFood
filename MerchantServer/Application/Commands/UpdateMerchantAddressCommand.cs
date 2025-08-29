using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class UpdateMerchantAddressCommand
    {
        private string _merchantId, _usersId, _street, _number, _complement, _ditrict, _city, _state, _country, _zipCode;
        private double _latitude, _longitude;
        public UpdateMerchantAddressCommand(string merchantId, string usersId, string street, string number, string complement, string ditrict, string city, string state, string country,
            string zipCode, double latitude, double longitude)
        {
            _merchantId = merchantId;
            _usersId = usersId;
            _street = street;
            _number = number;
            _complement = complement;
            _ditrict = ditrict;
            _city = city;
            _state = state;
            _country = country;
            _zipCode = zipCode;
            _latitude = latitude;
            _longitude = longitude;
        }

        public string MerchantId
        {
            get { return _merchantId; }
            set { _merchantId = value; }
        }
        public string UsersId
        {
            get { return _usersId; }
            set { _usersId = value; }
        }
        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }
        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }
        public string Complement
        {
            get { return _complement; }
            set { _complement = value; }
        }
        public string Ditrict
        {
            get { return _ditrict; }
            set { _ditrict = value; }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
        public string ZipCode
        {
            get { return _zipCode; }
            set { _zipCode = value; }
        }
        public double Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }
        public double Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }
    }
}
