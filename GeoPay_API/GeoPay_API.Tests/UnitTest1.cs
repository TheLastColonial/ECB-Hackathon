using GeoPay_API.Models;
using GeoPay_API.Repos;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private UserRepository userRepository;

        [SetUp]
        public void Setup()
        {
            userRepository = new UserRepository();
        }

        [Test]
        public void Test1()
        {
            User user = userRepository.GetUser(1);
        }
    }
}