namespace GeoPay_API.Models
{
    public class Payment
    {
        public string InitiatingPartyAccountNumber { get; set; }

        public string CounterPartyAccountNumber { get; set; }

        public decimal Amount { get; set; }

        public string CounterpartyName { get; set; }

        public string RemittanceInfo { get; set; }
    }
}
