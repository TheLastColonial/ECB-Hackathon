using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using Dapper;
using GeoPay_API.Models;

namespace GeoPay_API.Repos
{
    public class SubscriptionRepo : ISubscriptionRepo
    {
        private DbConnectionFactory dbConnectionFactory;

        public SubscriptionRepo()
        {
            dbConnectionFactory = new DbConnectionFactory();
        }

        public IEnumerable<Merchant> GetMerchants()
        {
            string sql = "SELECT Merchant.Id, Name, AccountNumber, Latitude, Longitude, Radius, GoogleReference FROM Merchant INNER JOIN Location ON Merchant.Id = Location.MerchantId";

            using (DbConnection connection = dbConnectionFactory.CreateAndOpenDb())
            {
                return connection.Query<Merchant>(sql).ToList();
            }
        }

        public List<Subscription> GetMerchantSubscriptions(int merchantId)
        {
            string sql = $"SELECT * FROM Subscription WHERE MerchantId = {merchantId}";

            using (DbConnection connection = dbConnectionFactory.CreateAndOpenDb())
            {
                return connection.Query<Subscription>(sql).ToList();
            }
        }

        public List<Subscription> GetUserSubscriptions(int userId)
        {
            string sql = $"SELECT * FROM Subscription WHERE UserId = {userId}";

            using (DbConnection connection = dbConnectionFactory.CreateAndOpenDb())
            {
                return connection.Query<Subscription>(sql).ToList();
            }
        }

        public int NewSubscription(int userId, int merchantId)
        {
            string sql = $"INSERT INTO Subscription VALUES (NULL, {userId}, {merchantId})";

            using (DbConnection connection = dbConnectionFactory.CreateAndOpenDb())
            {
                return connection.Execute(sql);
            }
        }
    }
}