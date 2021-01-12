using MediatR;
using Microsoft.Extensions.Logging;
using Skillz.Application.Dxos;
using Skillz.Contracts.Dto;
using Skillz.Contracts.Queries;
using Skillz.Models.Companies;
using Skillz.Models.Consultants;
using Skillz.Models.Entities.Profiles;
using Skillz.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Skillz.Application.QueryHandlers
{
    public class GetAllProfilesQueryHandler : IRequestHandler<GetAllProfilesQuery, IEnumerable<ProfileDto>>
    {
        private readonly IRepository<Profile> _profilesRepo;
        private readonly IProfilesDxos _profilesDxos;
        private readonly ILogger<GetAllProfilesQueryHandler> _logger;

        public GetAllProfilesQueryHandler(IRepository<Profile> profilesRepo, IProfilesDxos profilesDxos, ILogger<GetAllProfilesQueryHandler> logger)
        {
            _profilesRepo = profilesRepo ?? throw new ArgumentNullException(nameof(profilesRepo));
            _profilesDxos = profilesDxos ?? throw new ArgumentNullException(nameof(profilesDxos));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<ProfileDto>> Handle(GetAllProfilesQuery request, CancellationToken cancellationToken)
        {
            var profiles = await _profilesRepo.GetListAsync(e => e.IsDeleted == false);

            if (null != profiles)
            {
                _logger.LogInformation($"Request for profiles");
                return _profilesDxos.MapProfilesDto(profiles);
            }

            return null;
        }
    }
}
