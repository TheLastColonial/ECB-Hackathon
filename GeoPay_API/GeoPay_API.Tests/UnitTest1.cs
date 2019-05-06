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
            BankService bankService = new BankService();

            var result = await bankService.GetPaymentStatus("123");
        }
    }
}