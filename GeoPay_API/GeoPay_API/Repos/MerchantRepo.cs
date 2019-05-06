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
    public class MerchantRepo : IMerchantRepo
    {
        private DbConnectionFactory dbConnectionFactory;

        public MerchantRepo()
        {
            dbConnectionFactory = new DbConnectionFactory();
        }

        public void Add(Merchant merchant)
        {
            string sql = "INSERT INTO Merchant VALUES (NULL, @name, @accountNumber)";
                        
            using (DbConnection connection = dbConnectionFactory.CreateAndOpenDb())
            {
                connection.Execute(sql, new { name = merchant.Name, accountNumber = merchant.AccountNumber });
            }

            sql = "INSERT INTO Location VALUES (NULL, @latitude, @longitude, @radius, @googleReference, @amount)";

            using (DbConnection connection = dbConnectionFactory.CreateAndOpenDb())
            {
                connection.Execute(sql, new {
                    latitude = merchant.Latitude,
                    longitude = merchant.Longitude,
                    radius = merchant.Radius,
                    googleReference = merchant.GoogleReference,
                    amount = 5
                });
            }
        }

        public IEnumerable<Merchant> GetMerchants()
        {
            string sql = "SELECT Merchant.Id, Name, AccountNumber, Latitude, Longitude, Radius, GoogleReference FROM Merchant INNER JOIN Location ON Merchant.Id = Location.MerchantId";

            using (DbConnection connection = dbConnectionFactory.CreateAndOpenDb())
            {
                return connection.Query<Merchant>(sql).ToList();
            }
        }
    }
}