using Dapper;
using GeoPay_API.Models;
using System.Data.Common;

namespace GeoPay_API.Repos
{
    public class TransactionRepository : ITransactionRepository
    {
        private DbConnectionFactory dbConnectionFactory;

        public TransactionRepository()
        {
            dbConnectionFactory = new DbConnectionFactory();
        }

        public void Create(TransactionHistory transaction)
        {
            string sql = $"INSERT INTO TransactionHistory(Id, State, Amount, SubscriptionId, RemittanceInfo, BankTransactionId) "
            + $"Values(null, '{transaction.State}', {transaction.Amount}, {transaction.SubscriptionId}, '{transaction.RemittanceInfo}', '{transaction.BankTransactionId}')";
            using (DbConnection connection = dbConnectionFactory.CreateAndOpenDb())
            {
                connection.Execute(sql);
            }
        }

        public void Update(string state, string bankTransactionId)
        {
            string sql = "UPDATE TransactionHistory SET State = @State WHERE BankTransactionId = @BankTransactionId";
            using (DbConnection connection = dbConnectionFactory.CreateAndOpenDb())
            {
                connection.Execute(sql, new { State = state, BankTransactionId = bankTransactionId });
            }
        }
    }
}