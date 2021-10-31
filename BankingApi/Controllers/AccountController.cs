using AutoMapper;
using BankingApi.Dtos;
using BankingApi.Models;
using BankingApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;
        public AccountController(IMapper mapper, IAccountRepository accountRepository)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<GetAccountDto>> GetAccounts()
        {
            IEnumerable<Account> accounts = await _accountRepository.GetAccounts();
            IEnumerable<GetAccountDto> getAccountDtos = _mapper.Map<IEnumerable<GetAccountDto>>(accounts);
            return getAccountDtos;
        }

        [HttpGet("{id}")]
        public async Task<GetAccountDto> GetAccount(int id)
        {
            Account account = await _accountRepository.GetAccount(id);
            GetAccountDto getAccountDto = _mapper.Map<GetAccountDto>(account);
            return getAccountDto;
        }

        [HttpPost]
        public async Task<ActionResult<PostAccountDto>> PostAccount(PostAccountDto postAccountDto)
        {
            Account a = _mapper.Map<Account>(postAccountDto);
            await _accountRepository.AddAccount(a);
            return CreatedAtAction(nameof(GetAccount), new { id = a.Id }, postAccountDto);
        }

    }
}
