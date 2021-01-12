using MediatR;
using Microsoft.Extensions.Logging;
using Skillz.Application.Dxos;
using Skillz.Contracts.Dto;
using Skillz.Contracts.Queries;
using Skillz.Models.Companies;
using Skillz.Models.Consultants;
using Skillz.Models.Entities.Accounts;
using Skillz.Models.Entities.Skills;
using Skillz.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Skillz.Application.QueryHandlers
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, IEnumerable<SkillDto>>
    {
        private readonly IRepository<Skill> _repo;
        private readonly ISkillsDxos _dxos;
        private readonly ILogger<GetAllSkillsQueryHandler> _logger;

        public GetAllSkillsQueryHandler(IRepository<Skill> repo, ISkillsDxos dxos, ILogger<GetAllSkillsQueryHandler> logger)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _dxos = dxos ?? throw new ArgumentNullException(nameof(dxos));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<SkillDto>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            var d = await _repo.GetListAsync(e => e.IsDeleted == false);

            if (null != d)
            {
                _logger.LogInformation($"Request for accounts");
                return _dxos.MapSkillsDto(d);
            }

            return null;
        }
    }
}
