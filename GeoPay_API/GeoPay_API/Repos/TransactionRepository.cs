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
            + $"Values({transaction.Id}, {transaction.State}, {transaction.Amount}, {transaction.SubscriptionId}, {transaction.RemittanceInfo}, {transaction.BankTransactionId})";
            using (DbConnection connection = dbConnectionFactory.CreateAndOpenDb())
            {
                connection.Execute(sql);
            }
        }

        public void Update(int transactionId, string state, string bankTransactionId)
        {
            string sql = "UPDATE TransactionHistory SET State = @State, BankTransactionId = @TransactionId  WHERE Id = @Id";
            using (DbConnection connection = dbConnectionFactory.CreateAndOpenDb())
            {
                connection.Execute(sql, new { Id = transactionId, State = state, TransactionId = bankTransactionId });
            }
        }
    }
}