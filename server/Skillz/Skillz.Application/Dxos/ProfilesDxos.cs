using AutoMapper;
using Skillz.Contracts.Dto;
using Skillz.Models.Companies;
using Skillz.Models.Consultants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Application.Dxos
{
    public class ProfilesDxos: IProfilesDxos
    {
        private readonly IMapper _mapper;

        public ProfilesDxos()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Skillz.Models.Entities.Profiles.Profile, ProfileDto>();
            });
            _mapper = config.CreateMapper();
        }


        public ProfileDto MapProfiletDto(Skillz.Models.Entities.Profiles.Profile profile) {
            return _mapper.Map<Skillz.Models.Entities.Profiles.Profile, ProfileDto>(profile);
        }

        public List<ProfileDto> MapProfilesDto(IEnumerable<Skillz.Models.Entities.Profiles.Profile> profiles)
        {
            return _mapper.Map<List<ProfileDto>>(profiles);
        }
    }
}
