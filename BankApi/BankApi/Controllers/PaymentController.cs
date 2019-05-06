using FakeBankService.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FakeBankService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [HttpPost]
        public ActionResult<PaymentStatus> RegisterPayment([FromBody]Payment payment)
        {
            var paymentStatus = new PaymentStatus
            {
                AccountNumber = payment.InitiatingPartyAccountNumber,
                TransactionId = "321463282363179XX",
                Status = "STORED"
            };

            return this.Ok(JsonConvert.SerializeObject(paymentStatus));
        }

        [HttpPost("{transactionId}")]
        public ActionResult<PaymentStatus> ExecutePayment(string transactionId)
        {
            var paymentStatus = new PaymentStatus
            {
                AccountNumber = "NL62ABNA9999841479",
                TransactionId = transactionId,
                Status = "EXECUTED"
            };

            return this.Ok(JsonConvert.SerializeObject(paymentStatus));
        }

        [HttpGet("{transactionId}")]
        public ActionResult<PaymentStatus> GetPaymentStatus(string transactionId)
        {
            var paymentStatus = new PaymentStatus
            {
                AccountNumber = "NL62ABNA9999841479",
                TransactionId = transactionId,
                Status = "AUTHORIZED"
            };

            return this.Ok(JsonConvert.SerializeObject(paymentStatus));
        }
    }
}