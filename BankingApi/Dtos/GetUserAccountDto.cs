using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace BankingApi.Dtos
{
    public class GetUserAccountDto
    {
        public int Id { get; set; }
        public string NumberAccess { get; set; }
        public string Pin { get; set; }
        public int Balance { get; set; }
    }
}
