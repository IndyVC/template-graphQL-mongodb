using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Skillz.Application.Dxos;
using Skillz.Contracts.Dto;
using Skillz.Contracts.Queries;
using Skillz.Models.Entities.Profiles;
using Skillz.Models.Entities.Skills;
using Skillz.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Skillz.Application.QueryHandlers
{
    public class GetAllSkillsByProfilesQueryHandler : IRequestHandler<GetAllSkillsByProfileQuery, IEnumerable<SkillDto>>
    {
        private readonly IRepository<Skill> _repo;
        private readonly IRepository<SkillProfile> _sprepo;
        private readonly ISkillsDxos _dxos;
        private readonly ILogger<GetAllSkillsByProfilesQueryHandler> _logger;

        public GetAllSkillsByProfilesQueryHandler(IRepository<Skill> repo, IRepository<SkillProfile> sprepo, ISkillsDxos dxos, ILogger<GetAllSkillsByProfilesQueryHandler> logger)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _sprepo = sprepo ?? throw new ArgumentNullException(nameof(sprepo));
            _dxos = dxos ?? throw new ArgumentNullException(nameof(dxos));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<SkillDto>> Handle(GetAllSkillsByProfileQuery request, CancellationToken cancellationToken)
        {
            var q = await _sprepo.Query(s => s.ProfileId == request.ProfileId).Include(e => e.Skill).Select(s => s.Skill).ToListAsync();

            if (null != q)
            {
                _logger.LogInformation($"Request for profiles");
                return _dxos.MapSkillsDto(q);
            }

            return null;
        }
    }
}
