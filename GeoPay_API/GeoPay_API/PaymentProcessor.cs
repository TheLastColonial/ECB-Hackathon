﻿using GeoPay_API.Models;
using GeoPay_API.Repos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GeoPay_API
{
    public class PaymentProcessor
    {
        private BankService bankService;
        private TransactionRepository transactionRepository;

        public PaymentProcessor()
        {
            this.bankService = new BankService();
            this.transactionRepository = new TransactionRepository();
        }

        public async Task<string> RegisterPayment(int subscriptionId, [FromBody]Payment payment)
        {
            PaymentStatus paymentStatus = await this.bankService.RegisterPayment(payment);

            TransactionHistory transactionHistory = new TransactionHistory
            {
                State = paymentStatus.Status,
                Amount = payment.Amount,
                SubscriptionId = subscriptionId,
                RemittanceInfo = payment.RemittanceInfo,
                BankTransactionId = paymentStatus.TransactionId
            };

            this.transactionRepository.Create(transactionHistory);

            return paymentStatus.TransactionId;
        }

        public void RejectPayment(string transactionId)
        {
            this.transactionRepository.Update("REJECTED", transactionId);
        }

        public async Task<bool> ExecutePayment(string transactionId)
        {
            PaymentStatus paymentStatus = await this.bankService.ExecutePayment(transactionId);

            if (paymentStatus.Status != "EXECUTED")
            {
                this.transactionRepository.Update("FAILED", transactionId);
                return false;
            }

            this.transactionRepository.Update(paymentStatus.Status, transactionId);

            paymentStatus = await this.bankService.GetPaymentStatus(transactionId);

            if (paymentStatus.Status != "AUTHORIZED")
            {
                this.transactionRepository.Update("UNAUTHORIZED", transactionId);
                return false;
            }

            this.transactionRepository.Update(paymentStatus.Status, transactionId);
            return true;
        }
    }
}
