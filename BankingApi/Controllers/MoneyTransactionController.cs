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
    public class MoneyTransactionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMoneyTransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;

        public MoneyTransactionController(IMapper mapper, IMoneyTransactionRepository transactionRepository, IAccountRepository accountRepository)
        {
            _mapper = mapper;
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<MoneyTransactionDto>> GetTransactions()
        {
            IEnumerable<MoneyTransaction> transactions = await _transactionRepository.GetTransactions();
            IEnumerable<MoneyTransactionDto> transactionDtos = _mapper.Map<IEnumerable<MoneyTransactionDto>>(transactions);
            return transactionDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MoneyTransactionDto>> GetTransaction(int id)
        {
            MoneyTransaction transaction = await _transactionRepository.GetTransaction(id);
            if(transaction == null)
            {
                return NotFound();
            }
            MoneyTransactionDto transactionDto = _mapper.Map<MoneyTransactionDto>(transaction);
            return transactionDto;
        }

        //[HttpPost]
        //public async Task<ActionResult<MoneyTransactionDto>> PostTransaction(PostMoneyTransactionDto transactionDto)
        //{
        //    MoneyTransaction transaction = _mapper.Map<MoneyTransaction>(transactionDto);
        //    transaction.CreatedAt = DateTime.Now;
        //    await _transactionRepository.AddTransaction(transaction);
        //    transaction = await _transactionRepository.GetTransaction(transaction.Id);
        //    MoneyTransactionDto moneyTransactionDto = _mapper.Map<MoneyTransactionDto>(transaction);
        //    return CreatedAtAction(nameof(GetTransaction), new { id = transaction.Id }, moneyTransactionDto);
        //}

        [HttpPost]
        [Route("TransferMoney")]
        public async Task<ActionResult<MoneyTransactionDto>> TransferMoney(PostMoneyTransactionDto moneyTransactionDto)
        {
            MoneyTransaction moneyTransaction = _mapper.Map<MoneyTransaction>(moneyTransactionDto);
            moneyTransaction.CreatedAt = DateTime.Now;

            Account sender = await _accountRepository.GetAccount(moneyTransactionDto.SenderId);
            if(sender.Balance < moneyTransaction.Amount)
            {
                return BadRequest(new { msg = "Your balance is not enough" });
            }
            await _transactionRepository.TransferMoney(moneyTransaction);
            moneyTransaction = await _transactionRepository.GetTransaction(moneyTransaction.Id);
            MoneyTransactionDto result = _mapper.Map<MoneyTransactionDto>(moneyTransaction);
            return CreatedAtAction(nameof(GetTransaction), new { id = moneyTransaction.Id }, result);
        }

    }
}
