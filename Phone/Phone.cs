using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace poo_ap1
{
    public class Phone
    {
        public int CountryCode { get; protected set; }
        public int AreaCode { get; protected set; }
        public long Number { get; protected set; }

        public Phone(int countryCode, int areaCode, long number){
            this.CountryCode = countryCode;
            this.AreaCode = areaCode;
            this.Number = number;
        }

        public string CompletePhone(){
            string completePhone = $"+{this.CountryCode}{this.AreaCode}{this.Number}";
            return completePhone;
        }
    }
}