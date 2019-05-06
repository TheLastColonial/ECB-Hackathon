using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoPay_API.Models;

namespace GeoPay_API
{
    public class BankService : IBankService
    {
        public PaymentStatus ExecutePayment(string transactionId) => throw new NotImplementedException();

        public PaymentStatus GetPaymentStatus(string transactionId) => throw new NotImplementedException();

        public PaymentStatus RegisterPayment(Payment payment) => throw new NotImplementedException();
    }
}
