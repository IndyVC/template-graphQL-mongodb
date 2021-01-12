using MediatR;
using Microsoft.Extensions.Logging;
using Skillz.Application.Dxos;
using Skillz.Contracts.Commands;
using Skillz.Contracts.Dto;
using Skillz.Models.Companies;
using Skillz.Models.Consultants;
using Skillz.Models.Entities.Profiles;
using Skillz.Models.Events;
using Skillz.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Skillz.Application.CommandHandlers
{
    public class AddCompanyHandler : IRequestHandler<AddCompanyCommand, CompanyDto>
    {
        private readonly IRepository<Company> _companyRepo;
        private readonly ICompaniesDxos _companiesDxos;
        private readonly IMediator _mediator;

        public AddCompanyHandler(IRepository<Company> companyRepo, IMediator mediator, ICompaniesDxos companiesDxos)
        {
            _companyRepo = companyRepo ?? throw new ArgumentNullException(nameof(IRepository<Company>)); ;
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _companiesDxos = companiesDxos ?? throw new ArgumentNullException(nameof(companiesDxos));
        }

        public async Task<CompanyDto> Handle(AddCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = new Company(
                request.Title);

            _companyRepo.Add(company);

            if (await _companyRepo.SaveChangesAsync() == 0)
            {
                throw new ApplicationException();
            }

            await _mediator.Publish(new ConsultantCreatedEvent(company.Id), cancellationToken);
            var dto = _companiesDxos.MapCompanyDto(company);

            return dto;
        }
    }
}
