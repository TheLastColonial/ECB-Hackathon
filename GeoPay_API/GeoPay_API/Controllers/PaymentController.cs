using GeoPay_API.Models;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public async Task<JsonResult> Register(int subscriptionId, [FromBody]Payment payment)
        {
            string transactionId = await this.processor.RegisterPayment(subscriptionId, payment);

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