using GeoPay_API.Models;
using System;

namespace GeoPay_API.Repos
{
    public class TestGeoRepo : IGeoRepo
    {
        public Location GetMerchantLocation()
        {
            return new Location()
            {
                MerchantId = 1,
                GoogleRef = "GoogleRef",
                Lat = 1.1,
                Lng = 2.2,
                Radius = 100
            };
        }
    }
}
