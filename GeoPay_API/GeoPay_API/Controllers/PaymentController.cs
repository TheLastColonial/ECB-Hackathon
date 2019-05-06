using GeoPay_API.Models;
using GeoPay_API.Repos;
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

        private TransactionRepository transactionRepository { get; set; }

        public PaymentController()
        {
            this.processor = new PaymentProcessor();
            this.transactionRepository = new TransactionRepository();
        }

        [HttpGet("{merchantId}", Name = "Merchant Payment History")]
        public async Task<IActionResult> GetAllPayments(string merchantId)
        {
            if (string.IsNullOrWhiteSpace(merchantId)) return this.BadRequest(nameof(merchantId));

            try
            {
                var history = await this.transactionRepository.Get(merchantId);
                if (history.Count <= 0) return this.NotFound();

                return this.Ok(history);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }
        }

        [HttpPost(Name = "Init")]
        public async Task<JsonResult> Register(int subscriptionId, [FromBody]Payment payment)
        {
            string transactionId = await this.processor.RegisterPayment(subscriptionId, payment);

            return Json(new { TransactionId = transactionId });
        }
        
        [HttpPost("{transactionId}/Reject", Name = "Reject")]
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

        [HttpPost("{transactionId}", Name = "Confirm")]
        public async Task<JsonResult> Execute(string transactionId)
        {
            bool result = await this.processor.ExecutePayment(transactionId);

            return Json(new { Success = result });
        }
    }
}