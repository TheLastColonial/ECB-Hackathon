using Dapper;
using GeoPay_API.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

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

        public async Task<List<TransactionHistory>> Get(string merchantId)
        {
            string sql = $"SELECT * FROM TransactionHistory WHERE merchantId = @merchantId";

            using (DbConnection connection = dbConnectionFactory.CreateAndOpenDb())
            {
                var result = await connection.QueryAsync<TransactionHistory>(sql, new { merchantId });
                return result.AsList();
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