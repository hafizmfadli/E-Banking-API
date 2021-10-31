using BankingApi.Context;
using BankingApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApi.Repositories
{
    public class UserRepositoryEF : IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepositoryEF(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            user.CreatedAt = DateTime.Now;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
           User u = await _context.Users.Where(u => u.Id == id && !u.isDeleted).FirstOrDefaultAsync();
            u.DeletedAt = DateTime.Now;
            u.isDeleted = true;
            _context.Entry(u).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUser(int id)
        {
            return await _context.Users.Include(u => u.Accounts).Where(u => u.Id == id && !u.isDeleted).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.Include(u => u.Accounts).Where(u => !u.isDeleted).ToListAsync();
        }

        public async Task UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}