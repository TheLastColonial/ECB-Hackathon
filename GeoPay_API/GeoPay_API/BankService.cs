using GeoPay_API.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GeoPay_API
{
    public class BankService : IBankService
    {
        private HttpClient httpClient;

        public BankService()
        {
            httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:56449") };
        }

        public async Task<PaymentStatus> ExecutePayment(string transactionId)
        {
            HttpResponseMessage result = await this.httpClient.PostAsync($"/api/Payment/{transactionId}", null);

            return JsonConvert.DeserializeObject<PaymentStatus>(await result.Content.ReadAsStringAsync());
        }

        public async Task<PaymentStatus> GetPaymentStatus(string transactionId)
        {
            string result = await this.httpClient.GetStringAsync($"/api/Payment/{transactionId}");

            return JsonConvert.DeserializeObject<PaymentStatus>(result);
        }

        public async Task<PaymentStatus> RegisterPayment(Payment payment)
        {
            HttpResponseMessage result = await this.httpClient.PostAsJsonAsync("/api/Payment", payment);

            return JsonConvert.DeserializeObject<PaymentStatus>(await result.Content.ReadAsStringAsync());
        }
    }
}
