using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using Dapper;
using GeoPay_API.Models;

namespace GeoPay_API.Repos
{
    public class MerchantRepo : IMerchantRepo
    {
        public IEnumerable<Merchant> GetMerchants()
        {
            var dbFilePath = "../../ecb.db";
            if (!File.Exists(dbFilePath))
            {
                throw new Exception("Database file not found");
            }
            var _dbConnection = new SQLiteConnection(string.Format("Data Source={0};Version=3;", dbFilePath));
            _dbConnection.Open();
            return _dbConnection.Query<Merchant>("SELECT Id, Name, AccountNumber FROM Merchant").ToList();
        }
    }
}