using BankingApi.Context;
using BankingApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApi.Repositories
{
    public class TransactionRepositoryEF : IMoneyTransactionRepository
    {
        private readonly ApplicationContext _context;
        public TransactionRepositoryEF(ApplicationContext context)
        {
            _context = context;
        }
        public async Task AddTransaction(MoneyTransaction transaction)
        {
            transaction.CreatedAt = DateTime.Now;
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MoneyTransaction>> GetTransactions()
        {
            return await _context.Transactions
                        .Include(t => t.Sender.User)
                        .Include(t => t.Receiver.User)
                        .Where(t => !t.isDeleted).ToListAsync();
        }

        public async Task<MoneyTransaction> GetTransaction(int id)
        {
            MoneyTransaction t = await _context.Transactions
                                  .Include(t => t.Sender.User)
                                  .Include(t => t.Receiver.User)
                                  .Where(t => t.Id == id && !t.isDeleted).FirstOrDefaultAsync();
            return t;
        }

        public async Task TransferMoney(MoneyTransaction moneyTransaction)
        {
            Account sender = await _context.Accounts.Where(a => a.Id == moneyTransaction.SenderId && !a.isDeleted).FirstOrDefaultAsync();
            Account receiver = await _context.Accounts.Where(a => a.Id == moneyTransaction.ReceiverId && !a.isDeleted).FirstOrDefaultAsync();
            sender.Balance -= moneyTransaction.Amount;
            receiver.Balance += moneyTransaction.Amount;
            _context.Entry(sender).State = EntityState.Modified;
            _context.Entry(receiver).State = EntityState.Modified;
            _context.Transactions.Add(moneyTransaction);
            await _context.SaveChangesAsync();
        }
    }
}
