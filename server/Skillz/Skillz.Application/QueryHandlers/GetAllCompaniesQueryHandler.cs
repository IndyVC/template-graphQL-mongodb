using MediatR;
using Microsoft.Extensions.Logging;
using Skillz.Application.Dxos;
using Skillz.Contracts.Dto;
using Skillz.Contracts.Queries;
using Skillz.Models.Companies;
using Skillz.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Skillz.Application.QueryHandlers
{
    public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, IEnumerable<CompanyDto>>
    {
        private readonly IRepository<Company> _companiesRepo;
        private readonly ICompaniesDxos _companiesDxos;
        private readonly ILogger<GetAllCompaniesQueryHandler> _logger;

        public GetAllCompaniesQueryHandler(IRepository<Company> companiesRepo, ICompaniesDxos companiesDxos, ILogger<GetAllCompaniesQueryHandler> logger)
        {
            _companiesRepo = companiesRepo ?? throw new ArgumentNullException(nameof(companiesRepo));
            _companiesDxos = companiesDxos ?? throw new ArgumentNullException(nameof(companiesDxos));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<CompanyDto>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companies = await _companiesRepo.GetListAsync(e => e.IsDeleted == false);

            if (null != companies)
            {
                _logger.LogInformation($"Request for companies");
                return _companiesDxos.MapCompaniesDto(companies);
            }

            return null;
        }
    }
}
