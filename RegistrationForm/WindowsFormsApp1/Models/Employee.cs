using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class Employee
    {
        public Employee()
        {
            
            CommonInfo = new CommonInfo();
            ContactInfo = new ContactInfo();
        }
        
        public CommonInfo CommonInfo { get; set; }
        public ContactInfo ContactInfo { get; set; }
        
        public bool IsValid()
        {
            return CommonInfo.IsValid() && ContactInfo.IsValid();            
        }
    }
}
