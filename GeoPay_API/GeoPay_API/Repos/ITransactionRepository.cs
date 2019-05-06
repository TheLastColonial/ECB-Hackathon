using System;
using System.Collections.Generic;
using System.Linq;
using GeoPay_API.Models;

namespace GeoPay_API.Repos
{
    public interface ITransactionRepository
    {
        void Create(TransactionHistory transaction);

        void Update(int transactionId, string state, string bankTransactionId);
    }
}