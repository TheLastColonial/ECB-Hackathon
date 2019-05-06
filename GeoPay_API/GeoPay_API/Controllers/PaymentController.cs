using GeoPay_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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

        [HttpPost(Name = "Init")]
        public async Task<JsonResult> Register(int subscriptionId, [FromBody]Payment payment)
        {
            string transactionId = await this.processor.RegisterPayment(subscriptionId, payment);

            return Json(new { TransactionId = transactionId });
        }
        
        [HttpPost("Reject/{transactionId}", Name = "Reject")]
        public async Task<IActionResult> Rejected(string transactionId)
        {
            if (string.IsNullOrWhiteSpace(transactionId)) return this.BadRequest(nameof(transactionId));

            try
            {
                processor.RejectPayment(transactionId);
                return this.Ok(transactionId);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }
        }

        [HttpPost("/{transactionId}", Name = "Confirm")]
        public async Task<JsonResult> Execute(string transactionId)
        {
            bool result = await this.processor.ExecutePayment(transactionId);

            return Json(new { Success = result });
        }
    }
}