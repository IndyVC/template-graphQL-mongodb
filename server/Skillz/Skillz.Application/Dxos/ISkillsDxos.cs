using Skillz.Contracts.Dto;
using Skillz.Models.Entities.Skills;
using System.Collections.Generic;

namespace Skillz.Application.Dxos
{
    public interface ISkillsDxos
    {
        SkillDto MapSkillDto(Skill skill);

        public List<SkillDto> MapSkillsDto(IEnumerable<Skill> skills);
    }
}