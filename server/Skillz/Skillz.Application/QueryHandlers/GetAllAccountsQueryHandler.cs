using MediatR;
using Microsoft.Extensions.Logging;
using Skillz.Application.Dxos;
using Skillz.Contracts.Dto;
using Skillz.Contracts.Queries;
using Skillz.Models.Companies;
using Skillz.Models.Consultants;
using Skillz.Models.Entities.Accounts;
using Skillz.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Skillz.Application.QueryHandlers
{
    public class GetAllAccountsQueryHandler : IRequestHandler<GetAllAccountsQuery, IEnumerable<AccountDto>>
    {
        private readonly IRepository<Account> _repo;
        private readonly IAccountDxos _dxos;
        private readonly ILogger<GetAllAccountsQueryHandler> _logger;

        public GetAllAccountsQueryHandler(IRepository<Account> repo, IAccountDxos dxos, ILogger<GetAllAccountsQueryHandler> logger)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _dxos = dxos ?? throw new ArgumentNullException(nameof(dxos));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<AccountDto>> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
        {
            var d = await _repo.GetListAsync(e => e.IsDeleted == false);

            if (null != d)
            {
                _logger.LogInformation($"Request for accounts");
                return _dxos.MapAccountsDto(d);
            }

            return null;
        }
    }
}
