using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GeoPay_API.Repos
{
    public class DbConnectionFactory
    {
        public DbConnection CreateAndOpenDb()
        {
            var dbFilePath = "C:\\Projects\\ECB-Hackathon\\ecb.db";

            SQLiteConnection dbConnection = new SQLiteConnection(string.Format(
                "Data Source={0};Version=3;", dbFilePath));
            dbConnection.Open();

            return dbConnection;
        }
    }
}
