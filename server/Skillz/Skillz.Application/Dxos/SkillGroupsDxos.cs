using AutoMapper;
using Skillz.Contracts.Dto;
using Skillz.Models.Companies;
using Skillz.Models.Consultants;
using Skillz.Models.Entities.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Application.Dxos
{
    public class SkillGroupsDxos : ISkillGroupsDxos
    {
        private readonly IMapper _mapper;

        public SkillGroupsDxos()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SkillGroup, SkillGroupDto>();
            });
            _mapper = config.CreateMapper();
        }


        public SkillGroupDto MapSkillGroupDto(SkillGroup skillgroup) {
            return _mapper.Map<SkillGroup, SkillGroupDto>(skillgroup);
        }

        public List<SkillGroupDto> MapSkillGroupsDto(IEnumerable<SkillGroup> skillgroups)
        {
            return _mapper.Map<List<SkillGroupDto>>(skillgroups);
        }
    }
}
