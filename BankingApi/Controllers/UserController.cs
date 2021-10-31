using AutoMapper;
using BankingApi.Context;
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
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<GetUserDto>> GetUsers()
        {
           IEnumerable<User> users = await _userRepository.GetUsers();
           IEnumerable<GetUserDto> getUserDtos = _mapper.Map<IEnumerable<GetUserDto>>(users);
           return getUserDtos;
        }

        [HttpGet("{id}")]
        public async Task<GetUserDto> GetUser(int id)
        {
            User user = await _userRepository.GetUser(id);
            GetUserDto getUserDto = _mapper.Map<GetUserDto>(user);
            return getUserDto;
        }

        [HttpPost]
        public async Task<ActionResult<PostUserDto>> PostUser(PostUserDto user)
        {
            User u = _mapper.Map<User>(user);
           await _userRepository.AddUser(u);
           return CreatedAtAction(nameof(GetUser), new { id = u.Id }, user);
        }
    }
}
