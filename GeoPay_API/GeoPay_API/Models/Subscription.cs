using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoPay_API.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public int MerchantId { get; set; }
        public int UserId { get; set; }
    }
}
