using System.Data.Common;
using System.Data.SQLite;

namespace GeoPay_API.Repos
{
    public class DbConnectionFactory
    {
        public DbConnection CreateAndOpenDb()
        {
            var dbFilePath = ".\\ecb.db";

            SQLiteConnection dbConnection = new SQLiteConnection(string.Format(
                "Data Source={0};Version=3;", dbFilePath));
            dbConnection.Open();

            return dbConnection;
        }
    }
}
