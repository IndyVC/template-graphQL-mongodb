using MediatR;
using Microsoft.Extensions.Logging;
using Skillz.Application.Dxos;
using Skillz.Contracts.Dto;
using Skillz.Contracts.Queries;
using Skillz.Models.Companies;
using Skillz.Models.Consultants;
using Skillz.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Skillz.Application.QueryHandlers
{
    public class GetAllConsultantsQueryHandler : IRequestHandler<GetAllConsultantsQuery, IEnumerable<ConsultantDto>>
    {
        private readonly IRepository<Consultant> _consultantsRepo;
        private readonly IConsultantsDxos _consultantsDxos;
        private readonly ILogger<GetAllConsultantsQueryHandler> _logger;

        public GetAllConsultantsQueryHandler(IRepository<Consultant> consultantsRepo, IConsultantsDxos consultantsDxos, ILogger<GetAllConsultantsQueryHandler> logger)
        {
            _consultantsRepo = consultantsRepo ?? throw new ArgumentNullException(nameof(consultantsRepo));
            _consultantsDxos = consultantsDxos ?? throw new ArgumentNullException(nameof(consultantsDxos));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<ConsultantDto>> Handle(GetAllConsultantsQuery request, CancellationToken cancellationToken)
        {
            var consultants = await _consultantsRepo.GetListAsync(e => e.IsDeleted == false);

            if (null != consultants)
            {
                _logger.LogInformation($"Request for consultants");
                return _consultantsDxos.MapConsultantsDto(consultants);
            }

            return null;
        }
    }
}
