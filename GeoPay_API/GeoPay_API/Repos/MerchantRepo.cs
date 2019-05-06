using System;
using System.Collections.Generic;
using System.Data.SQLite.Core;
using System.Linq;
using GeoPay_API.Models;

namespace GeoPay_API.Repos
{
    public class MerchantRepo : IMerchantRepo
    {
        public IEnumerable<Merchant> GetMerchants()
        {
            var dbFilePath = "../ecb.db";
            var _dbConnection = new SQLiteConnection(string.Format("Data Source={0};Version=3;", dbFilePath));
            _dbConnection.Open();
            return _dbConnection.Query<Merchant>("Select * From Merchant").ToList();
        }
    }
}