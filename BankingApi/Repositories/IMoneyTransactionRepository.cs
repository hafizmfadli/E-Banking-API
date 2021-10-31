using BankingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApi.Repositories
{
    public interface IMoneyTransactionRepository
    {
        public Task AddTransaction(MoneyTransaction transaction);
        public Task<IEnumerable<MoneyTransaction>> GetTransactions();
        public Task<MoneyTransaction> GetTransaction(int id);
        public Task TransferMoney(MoneyTransaction moneyTransaction);
    }
}
