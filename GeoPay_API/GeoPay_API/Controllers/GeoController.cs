using GeoPay_API.Repos;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GeoPay_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeoController : ControllerBase
    {
        private IGeoRepo GeoRepo { get; set; } = new TestGeoRepo();

        [HttpGet]
        public IActionResult GetMerchantLocation(int merchantId)
        {
            if (merchantId == null) return BadRequest(nameof(merchantId));

            try
            {
                var location = this.GeoRepo.GetMerchantLocation(merchantId);
                if (location == null) return this.NotFound();
                return this.Ok(location);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }
            
        }
    }
}