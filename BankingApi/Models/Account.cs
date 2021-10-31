using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApi.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string NumberAccess { get; set; }
        public string Pin { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int Balance { get; set; }

        [InverseProperty("Sender")]
        public ICollection<MoneyTransaction> TransactionSent { get; set; }
        [InverseProperty("Receiver")]
        public ICollection<MoneyTransaction> TransactionReceived { get; set; }

        public bool isDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
