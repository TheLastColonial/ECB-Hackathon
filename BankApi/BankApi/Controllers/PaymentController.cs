using FakeBankService.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;

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
                TransactionId = this.GetRandomString(16),
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

        private string GetRandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}