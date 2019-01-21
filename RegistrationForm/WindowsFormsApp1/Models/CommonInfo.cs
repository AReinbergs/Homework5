using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Enums;
using WindowsFormsApp1.Helpers;

namespace WindowsFormsApp1.Models
{
    public class CommonInfo
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? Birthday { get; set; }
        public string Ssn { get; set; }
        public GenderEnum Gender { get; set; }

        public bool IsValid()
        {
            return Validator.ValidateNameOrSurname(Name) &&
                    Validator.ValidateNameOrSurname(Surname) &&
                    Birthday.HasValue &&
                    Validator.ValidateSsn(Ssn, Birthday) &&
                    Gender != 0;
        }
    }
}
