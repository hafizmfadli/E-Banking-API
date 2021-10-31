using BankingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApi.Dtos
{
    public class MoneyTransactionDto
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public string SenderNumberAccess { get; set; }
        public int ReceiverId { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverNumberAccess { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
