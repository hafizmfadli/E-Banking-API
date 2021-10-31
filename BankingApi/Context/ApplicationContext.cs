using BankingApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApi.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<MoneyTransaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Fullname = "Hafiz Muhammad Fadli",
                    isDeleted = false,
                    CreatedAt = DateTime.Now,
                    DeletedAt = DateTime.MinValue
                },
                new User
                {
                    Id = 2,
                    Fullname = "Uzumaki Naruto",
                    isDeleted = false,
                    CreatedAt = DateTime.Now,
                    DeletedAt = DateTime.MinValue
                }
                );
            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    Id = 1,
                    NumberAccess = "xxx123",
                    Pin = "123456",
                    UserId = 1,
                    Balance = 500000,
                    isDeleted = false,
                    CreatedAt = DateTime.Now,
                    DeletedAt = DateTime.MinValue
                },
                new Account
                {
                    Id = 2,
                    NumberAccess = "xxx456",
                    Pin = "654321",
                    UserId = 2,
                    Balance = 700000,
                    isDeleted = false,
                    CreatedAt = DateTime.Now,
                    DeletedAt = DateTime.MinValue
                }
                );
            modelBuilder.Entity<MoneyTransaction>().HasData(
                new MoneyTransaction
                {
                    Id = 1,
                    SenderId = 1,
                    ReceiverId = 2,
                    isDeleted = false,
                    Amount = 100000,
                    CreatedAt = DateTime.Now,
                    DeletedAt = DateTime.MinValue
                },
                new MoneyTransaction
                {
                    Id = 2,
                    SenderId = 1,
                    ReceiverId = 2,
                    isDeleted = false,
                    Amount = 50000,
                    CreatedAt = DateTime.Now,
                    DeletedAt = DateTime.MinValue
                }
                );
        }
    }
  
}
