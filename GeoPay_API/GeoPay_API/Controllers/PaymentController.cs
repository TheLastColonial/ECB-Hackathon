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
    public class PaymentController : Controller
    {
        private PaymentProcessor processor { get; set; }

        public PaymentController()
        {
            this.processor = new PaymentProcessor();
        }

        [HttpPost]
        public async Task<JsonResult> Register(Payment payment)
        {
            string transactionId = await this.processor.RegisterPayment(payment);

            return Json(new { TransactionId = transactionId });
        }

        [HttpPost("/{transactionId}")]
        public async Task<JsonResult> Execute(string transactionId)
        {
            bool result = await this.processor.ExecutePayment(transactionId);

            return Json(new { Success = result });
        }
    }
}