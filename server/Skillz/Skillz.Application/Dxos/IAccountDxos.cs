using Skillz.Contracts.Dto;
using Skillz.Models.Consultants;
using Skillz.Models.Entities.Accounts;
using System.Collections.Generic;

namespace Skillz.Application.Dxos
{
    public interface IAccountDxos
    {
        AccountDto MapAccountDto(Account account);
        List<AccountDto> MapAccountsDto(IEnumerable<Account> accounts);
    }
}
