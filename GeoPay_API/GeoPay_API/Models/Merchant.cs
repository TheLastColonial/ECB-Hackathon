namespace GeoPay_API.Models
{
    public class Merchant 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AccountNumber { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public int Radius { get; set; }

        public string GoogleReference { get; set; }
    }
}