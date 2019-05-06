using GeoPay_API.Models;

namespace GeoPay_API.Repos
{
    public interface IGeoRepo
    {
        Location GetMerchantLocation();
    }
}
