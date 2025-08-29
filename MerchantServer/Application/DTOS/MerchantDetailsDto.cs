using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS
{
    public class MerchantDetailsDto
    {
        public string Id { get; set; }
        public string UUID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Complement { get; set; }
        public string shortAddress { get; set; }
        public string DeliveryPhone { get; set; }
        public string OwnerPhone { get; set; }

        public MinOrderDto MinimumOrderValue { get; set; }
        public LocationDto Location { get; set; }

        public string Description { get; set; }

        public string Logo { get; set; }

        public string Country { get; set; }

        public string State { get; set; }
        public string City { get; set; }

        public string District { get; set; }
        public string Cover { get; set; }
        public string mainCuisine { get; set; }
        public string Type { get; set; }


    }

    public class MinOrderDto
    {
        public string Currency { get; set; }
        public double Value { get; set; }
     
    }

    public class LocationDto
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }

    public class AddressDto
    {
        public string ZipCode { get; set; }
        public string StreetNumber { get; set; }
        public string Adress { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Reference { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}