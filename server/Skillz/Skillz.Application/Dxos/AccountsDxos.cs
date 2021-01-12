using AutoMapper;
using Skillz.Contracts.Dto;
using Skillz.Models.Companies;
using Skillz.Models.Consultants;
using Skillz.Models.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Application.Dxos
{
    public class AccountsDxos: IAccountDxos
    {
        private readonly IMapper _mapper;

        public AccountsDxos()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Account, AccountDto>();
            });
            _mapper = config.CreateMapper();
        }


        public AccountDto MapAccountDto(Account account)
        {
            return _mapper.Map<Account, AccountDto>(account);
        }

        public List<AccountDto> MapAccountsDto(IEnumerable<Account> accounts)
        {
            return _mapper.Map<List<AccountDto>>(accounts);
        }
    }
}


