using GeoPay_API.Models;
using System.Threading.Tasks;

namespace GeoPay_API
{
    public interface IBankService
    {
        Task<PaymentStatus> RegisterPayment(Payment payment);

        Task<PaymentStatus> ExecutePayment(string transactionId);

        Task<PaymentStatus> GetPaymentStatus(string transactionId);
    }
}
