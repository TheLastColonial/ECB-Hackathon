using System;
using System.Collections.Generic;
using System.Linq;
using GeoPay_API.Models;
using GeoPay_API.Repos;
using Microsoft.AspNetCore.Mvc;

namespace GeoPay_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantController : ControllerBase
    {
        private IMerchantRepo merchantRepo { get; set; }

        public MerchantController()
        {
            this.merchantRepo = new MerchantRepo();
        }

        [HttpGet]
        public IEnumerable<Merchant> Get()
        {
            return this.merchantRepo.GetMerchants();
        }

        [HttpPost]
        public IActionResult SetUserSubscription(int userId, [FromBody]List<Merchant> merchants)
        {
            if (userId == null) return this.BadRequest(nameof(userId));
            if (merchants.Count <= 0) return this.BadRequest(nameof(merchants));

            try
            {
                return this.Created($"api/subscription/{1}", new Subscription()
                {
                    Id = 1,
                    MerchantId = 1,
                    UserId = userId
                });
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }
        }


    }
}