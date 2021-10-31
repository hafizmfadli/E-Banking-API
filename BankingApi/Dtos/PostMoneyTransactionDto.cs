using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApi.Dtos
{
    public class PostMoneyTransactionDto
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public int Amount { get; set; }
    }
}
