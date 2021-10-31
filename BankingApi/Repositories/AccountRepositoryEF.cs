using BankingApi.Context;
using BankingApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApi.Repositories
{
    public class AccountRepositoryEF : IAccountRepository
    {
        private readonly ApplicationContext _context;

        public AccountRepositoryEF(ApplicationContext context)
        {
            _context = context;
        }
        public async Task AddAccount(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAccount(int id)
        {
            Account account = await _context.Accounts.Where(a => a.Id == id).FirstOrDefaultAsync();
            account.isDeleted = true;
            account.DeletedAt = DateTime.Now;
            _context.Entry(account).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Account> GetAccount(int id)
        {
            return await _context.Accounts
                        .Include(a => a.TransactionReceived)
                        .Include(a => a.TransactionSent)
                        .Include(a => a.User)
                        .Where(a => a.Id == id && !a.isDeleted).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await _context.Accounts
                        .Include(a => a.TransactionReceived)
                        .Include(a => a.TransactionSent)
                        .Include(a => a.User)
                        .Where(a => !a.isDeleted)
                        .ToListAsync();
        }

        public async Task UpdateAccount(Account account)
        {
            _context.Entry(account).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
