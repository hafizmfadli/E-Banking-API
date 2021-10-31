using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public ICollection<Account> Accounts { get; set; }
        public bool isDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

    }
}
