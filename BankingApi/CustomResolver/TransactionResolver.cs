using AutoMapper;
using BankingApi.Dtos;
using BankingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApi.CustomResolver
{
    public class TransactionResolver : IValueResolver<MoneyTransaction, MoneyTransactionDto, string>
    {
        public string Resolve(MoneyTransaction source, MoneyTransactionDto destination, string destMember, ResolutionContext context)
        {
            destMember = source.Sender.User.Fullname;
            return destMember;
        }
    }
}
