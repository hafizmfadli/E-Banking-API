using BankingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApi.Repositories
{
    public interface IAccountRepository
    {
        public Task AddAccount(Account account);
        public Task<IEnumerable<Account>> GetAccounts();
        public Task<Account> GetAccount(int id);
        public Task UpdateAccount(Account account);
        public Task DeleteAccount(int id);
    }
}
