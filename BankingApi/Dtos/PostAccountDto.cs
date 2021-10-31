using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApi.Dtos
{
    public class PostAccountDto
    {
        public string NumberAccess { get; set; }
        public string Pin { get; set; }
        public int UserId { get; set; }
        public int Balance { get; set; }
    }
}
