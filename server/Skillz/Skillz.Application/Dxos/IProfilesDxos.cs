
using Skillz.Contracts.Dto;
using Skillz.Models.Consultants;
using Skillz.Models.Entities.Profiles;
using System.Collections.Generic;

namespace Skillz.Application.Dxos
{
    public interface IProfilesDxos
    {
        ProfileDto MapProfiletDto(Skillz.Models.Entities.Profiles.Profile profile);
        List<ProfileDto> MapProfilesDto(IEnumerable<Skillz.Models.Entities.Profiles.Profile> profiles);
    }
}
