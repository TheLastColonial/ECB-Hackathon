namespace GeoPay_API.Models
{
    public class TransactionHistory 
    {
        public int Id { get; set; }

        public string State { get; set; }

        public decimal Amount { get; set; }

        public int SubscriptionId { get; set; }

        public string RemittanceInfo { get; set; }

        public string BankTransactionId { get; set; }
    }
}