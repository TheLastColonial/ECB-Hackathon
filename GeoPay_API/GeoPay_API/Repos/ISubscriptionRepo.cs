using GeoPay_API.Models;
using System.Collections.Generic;

namespace GeoPay_API.Repos
{
    public interface ISubscriptionRepo
    {
        List<Subscription> GetUserSubscriptions(int userId);

        List<Subscription> GetMerchantSubscriptions(int merchantId);

        int NewSubscription(int userId, int merchantId);
    }
}
