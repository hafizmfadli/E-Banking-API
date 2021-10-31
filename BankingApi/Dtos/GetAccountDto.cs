using BankingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApi.Dtos
{
    public class GetAccountDto
    {
        public int Id { get; set; }
        public string NumberAccess { get; set; }
        public string Pin { get; set; }
        public int UserId { get; set; }
        public int Balance { get; set; }
        public string Fullname { get; set; }
        //public ICollection<TransactionDto> Transactions { get; set; }
    }
}
