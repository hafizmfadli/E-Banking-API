using AutoMapper;
using BankingApi.CustomResolver;
using BankingApi.Dtos;
using BankingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApi.Profiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<PostUserDto, User>();
            CreateMap<Account, GetUserAccountDto>();
            CreateMap<User, GetUserDto>();
            CreateMap<Account, GetAccountDto>()
                .ForMember(dest => dest.Fullname, opt => opt.MapFrom(src => src.User.Fullname));
            CreateMap<MoneyTransaction, MoneyTransactionDto>()
                .ForMember(dest => dest.SenderName, opt => opt.MapFrom(src => src.Sender.User.Fullname))
                .ForMember(dest => dest.ReceiverName, opt => opt.MapFrom(src => src.Receiver.User.Fullname))
                .ForMember(dest => dest.SenderNumberAccess, opt => opt.MapFrom(src => src.Sender.NumberAccess))
                .ForMember(dest => dest.ReceiverNumberAccess, opt => opt.MapFrom(src => src.Receiver.NumberAccess));
            CreateMap<MoneyTransactionDto, MoneyTransaction>();
            CreateMap<MoneyTransaction, PostMoneyTransactionDto>();
            CreateMap<PostMoneyTransactionDto, MoneyTransaction>();
            CreateMap<PostAccountDto, Account>();
        }
    }
}
