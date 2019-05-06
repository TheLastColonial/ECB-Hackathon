using GeoPay_API.Models;

namespace GeoPay_API
{
    public interface IBankService
    {
        PaymentStatus RegisterPayment(Payment payment);

        PaymentStatus ExecutePayment(string transactionId);

        PaymentStatus GetPaymentStatus(string transactionId);
    }
}
