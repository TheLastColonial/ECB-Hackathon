using GeoPay_API.Models;
using System.Threading.Tasks;

namespace GeoPay_API
{
    public class PaymentProcessor
    {
        private BankService bankService;

        public PaymentProcessor()
        {
            this.bankService = new BankService();
        }

        public async Task<string> RegisterPayment(Payment payment)
        {
            PaymentStatus paymentStatus = await this.bankService.RegisterPayment(payment);

            // Todo: write TransactionHistory entry

            return paymentStatus.TransactionId;
        }

        public async Task<bool> ExecutePayment(string transactionId)
        {
            PaymentStatus paymentStatus = await this.bankService.ExecutePayment(transactionId);

            if (paymentStatus.Status != "EXECUTED")
            {
                // Todo: write TransactionHistory entry
                return false;
            }

            // Todo: write TransactionHistory entry

            paymentStatus = await this.bankService.GetPaymentStatus(transactionId);

            if (paymentStatus.Status != "AUTHORIZED")
            {
                // Todo: write TransactionHistory entry
                return false;
            }

            return true;
            // Todo: write TransactionHistory entry
        }
    }
}
