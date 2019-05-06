using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoPay_API.Repos;
using Microsoft.AspNetCore.Mvc;

namespace GeoPay_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        public ISubscriptionRepo SubscriptionRepo { get; set; } = new SubscriptionRepo();
        public IMerchantRepo MerchantRepo { get; set; } = new MerchantRepo();

        [HttpGet(Name = "UserSubscriptions")]
        public IActionResult GetSubscriptionUser(int userId)
        {
            if (userId == null) return this.BadRequest(nameof(userId));
            
            var subs = this.SubscriptionRepo.GetUserSubscriptions(userId);

            if (subs == null || subs.Count <= 0)
            {
                return NotFound();
            }

            return this.Ok(subs);
        }
        
        [HttpPost]
        public IActionResult CreateSubscription(int userId, int merchantId)
        {
            if (userId == null) return this.BadRequest(nameof(userId));
            if (merchantId == null) return this.BadRequest(nameof(merchantId));

            try
            {
                if (!this.MerchantRepo.GetMerchants().Any(x => x.Id == userId))
                {
                    return this.NotFound(nameof(merchantId));
                }

                // TODO Check User

                var subscriptionId = this.SubscriptionRepo.NewSubscription(userId, merchantId);

                return this.Ok(subscriptionId);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }            
        }
    }
}