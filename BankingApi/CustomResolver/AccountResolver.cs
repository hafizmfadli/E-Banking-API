using AutoMapper;
using BankingApi.Dtos;
using BankingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApi.CustomResolver
{
    public class AccountResolver : IValueResolver<Account, GetAccountDto, ICollection<MoneyTransaction>>
    {
        public ICollection<MoneyTransaction> Resolve(Account source, GetAccountDto destination, ICollection<MoneyTransaction> destMember, ResolutionContext context)
        {
            //destMember.Concat(source.TransactionSent);
            //destMember.Concat(source.TransactionReceived);
            //if(source.TransactionReceived != null)
            //{
            //    foreach (var transaction in source.TransactionReceived)
            //    {
            //        destMember.Add(transaction);
            //    }
            //}
            //if(source.TransactionSent != null)
            //{
            //    foreach (var transaction in source.TransactionSent)
            //    {
            //        destMember.Add(transaction);
            //    }
            //}
            var allTransactions = source.TransactionReceived.Concat(source.TransactionSent);
         
            return (ICollection<MoneyTransaction>)allTransactions;
        }
    }
}
