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