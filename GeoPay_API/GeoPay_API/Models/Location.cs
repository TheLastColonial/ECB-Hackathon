using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoPay_API.Models
{
    public class Location
    {
        public int MerchantId { get; set; }
        public string GoogleRef { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public int Radius { get; set; }
    }
}
