using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApi.Models
{
    public class MoneyTransaction
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        [ForeignKey("Sender")]
        public int SenderId { get; set; }
        public Account Sender { get; set; }
        [ForeignKey("Receiver")]
        public int ReceiverId { get; set; }
        public Account Receiver { get; set; }
        public bool isDeleted { get; set; }
        public DateTime DeletedAt { get; set; }
        public int Amount { get; set; }
    }
}
