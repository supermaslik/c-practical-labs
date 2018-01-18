using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CollectionFunctions.Models
{
    public class User
    {
        public string Name { get; set; }
        public string SName { get; set; }
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }

            set
            {
                Regex reg = new Regex(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{8,10}$");
                if(reg.IsMatch(value))
                phoneNumber = value;
            }
        }

        private string phoneNumber;
    }
}
