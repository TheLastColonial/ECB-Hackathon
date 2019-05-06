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
        public JsonResult Get()
        {
            var merchants = this.merchantRepo.GetMerchants();
            return Json(new { Merchants = merchants });
        }
    }
}