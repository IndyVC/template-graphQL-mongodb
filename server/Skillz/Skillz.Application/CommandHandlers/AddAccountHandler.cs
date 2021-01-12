using MediatR;
using Microsoft.EntityFrameworkCore;
using Skillz.Application.Dxos;
using Skillz.Contracts.Commands;
using Skillz.Contracts.Dto;
using Skillz.Models.Consultants;
using Skillz.Models.Entities.Accounts;
using Skillz.Models.Entities.People;
using Skillz.Models.Events;
using Skillz.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Skillz.Application.CommandHandlers
{
    public class AddAccountHandler : IRequestHandler<AddAccountCommand, AccountDto>
    {
        private readonly IRepository<Account> _repo;
        private readonly IMediator _mediator;
        private readonly IAccountDxos _dxo;

        public AddAccountHandler(IRepository<Account> repo, IMediator mediator, IAccountDxos dxo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(IRepository<Account>)); ;
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _dxo = dxo ?? throw new ArgumentNullException(nameof(dxo));
        }

        public async Task<AccountDto> Handle(AddAccountCommand request, CancellationToken cancellationToken)
        {
            var account = new Account(
                request.Title,
                request.CompanyId);



            _repo.Add(account);

            if (await _repo.SaveChangesAsync() == 0)
            {
                throw new ApplicationException();
            }

            //await _mediator.Publish(new ConsultantCreatedEvent(employee.Id), cancellationToken);

            var nw = await _repo.Query(e => e.Id == account.Id).SingleAsync();
            var dto = _dxo.MapAccountDto(nw);

            return dto;
        }
    }
}
