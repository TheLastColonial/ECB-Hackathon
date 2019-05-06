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
    public class MerchantController : Controller
    {
        private IMerchantRepo merchantRepo { get; set; }

        public MerchantController()
        {
            this.merchantRepo = new MerchantRepo();
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var merchants = this.merchantRepo.GetMerchants();
            return Json(new { Merchants = merchants });

            //try
            //{
            //    var merchants = this.merchantRepo.GetMerchants();

            //    if (merchants == null || merchants.ToList().Count <= 0)
            //    {
            //        return this.NotFound();
            //    }

            //    return this.Ok(merchants);
            //}
            //catch (Exception ex)
            //{
            //    return this.StatusCode(500, ex.Message);
            //}
        }

        [Obsolete]
        [HttpPost]
        public IActionResult SetUserSubscription(int userId, [FromBody]List<int> merchantId)
        {
            if (userId == null) return this.BadRequest(nameof(userId));
            if (merchantId.Count <= 0) return this.BadRequest(nameof(merchantId));

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