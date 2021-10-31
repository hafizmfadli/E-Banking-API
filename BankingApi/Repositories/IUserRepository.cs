using BankingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApi.Repositories
{
    public interface IUserRepository
    {
        public Task AddUser(User user);
        public Task<IEnumerable<User>> GetUsers();
        public Task<User> GetUser(int id);
        public Task UpdateUser(User user);
        public Task DeleteUser(int id);

    }
}
