using Dapper;
using GeoPay_API.Models;
using System.Data.Common;
using System.Linq;

namespace GeoPay_API.Repos
{
    public class UserRepository
    {
        private DbConnectionFactory dbConnectionFactory;

        public UserRepository()
        {
            dbConnectionFactory = new DbConnectionFactory();
        }

        public User GetUser(int id)
        {
            string sql = $"SELECT * FROM User WHERE id = {id}";

            using (DbConnection connection = dbConnectionFactory.CreateAndOpenDb())
            {
                return connection.Query<User>(sql).FirstOrDefault();
            }
        }
    }
}
