using Skillz.Contracts.Dto;
using Skillz.Models.Entities.Skills;
using System.Collections.Generic;

namespace Skillz.Application.Dxos
{
    public interface ISkillGroupsDxos
    {
        SkillGroupDto MapSkillGroupDto(SkillGroup skillgroup);

        public List<SkillGroupDto> MapSkillGroupsDto(IEnumerable<SkillGroup> skillgroups);
    }
}