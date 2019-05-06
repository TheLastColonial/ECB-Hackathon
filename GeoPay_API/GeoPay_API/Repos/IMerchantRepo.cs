using System.Collections.Generic;
using GeoPay_API.Models;

namespace GeoPay_API.Repos
{
    public interface IMerchantRepo
    {
        IEnumerable<Merchant> GetMerchants();
        void Add(Merchant merchant);
    }
}