﻿using BankingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApi.Dtos
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public virtual ICollection<GetUserAccountDto> Accounts { get; set; }
    }
}
