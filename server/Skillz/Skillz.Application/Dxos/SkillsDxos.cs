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
    public class SkillsDxos : ISkillsDxos
    {
        private readonly IMapper _mapper;

        public SkillsDxos()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Skill, SkillDto>();
            });
            _mapper = config.CreateMapper();
        }


        public SkillDto MapSkillDto(Skill skill) {
            return _mapper.Map<Skill, SkillDto>(skill);
        }

        public List<SkillDto> MapSkillsDto(IEnumerable<Skill> skills)
        {
            return _mapper.Map<List<SkillDto>>(skills);
        }
    }
}
