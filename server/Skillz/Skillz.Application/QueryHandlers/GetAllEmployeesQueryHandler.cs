using MediatR;
using Microsoft.Extensions.Logging;
using Skillz.Application.Dxos;
using Skillz.Contracts.Dto;
using Skillz.Contracts.Queries;
using Skillz.Models.Companies;
using Skillz.Models.Consultants;
using Skillz.Models.Entities.Accounts;
using Skillz.Models.Entities.People;
using Skillz.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Skillz.Application.QueryHandlers
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeDto>>
    {
        private readonly IRepository<Employee> _repo;
        private readonly IEmployeesDxos _dxos;
        private readonly ILogger<GetAllEmployeesQueryHandler> _logger;

        public GetAllEmployeesQueryHandler(IRepository<Employee> repo, IEmployeesDxos dxos, ILogger<GetAllEmployeesQueryHandler> logger)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _dxos = dxos ?? throw new ArgumentNullException(nameof(dxos));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<EmployeeDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var d = await _repo.GetListAsync(e => e.IsDeleted == false);

            if (null != d)
            {
                _logger.LogInformation($"Request for employees");
                return _dxos.MapEmployeesDto(d);
            }

            return null;
        }
    }
}
