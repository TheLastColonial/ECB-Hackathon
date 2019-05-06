using GeoPay_API;
using GeoPay_API.Models;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            PaymentProcessor paymentProcessor = new PaymentProcessor();


            var result = await paymentProcessor.ExecutePayment("321463282363179XX");
        }
    }
}