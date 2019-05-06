using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public JsonResult Get()
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
        
        [HttpPost(Name = "Onboarding")]
        public async Task<IActionResult> Onboarding([FromBody] Merchant merchant)
        {
            if (merchant == null) return this.BadRequest(nameof(merchant));
            
            try
            {
                this.merchantRepo.Add(merchant);

                return this.Ok();
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }
        }
    }
}