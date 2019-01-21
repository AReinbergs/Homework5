using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Enums;
using WindowsFormsApp1.Helpers;

namespace WindowsFormsApp1.Models
{
    public class ContactInfo
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public CountryEnum Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string FullAddress { get; set; }

        public bool IsValid()
        {
            return Validator.ValidateEmail(Email) &&
                   Validator.ValidateNumber(Phone) &&
                   Validator.ValidateCity(City) &&
                   Country != 0 &&
                   Validator.ValidateStreet(Street) &&
                   Validator.ValidateZipCode(ZipCode);
        }
    }
}
