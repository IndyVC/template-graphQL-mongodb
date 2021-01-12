using AutoMapper;
using Skillz.Contracts.Dto;
using Skillz.Models.Companies;
using Skillz.Models.Consultants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Application.Dxos
{
    public class ConsultantsDxos: IConsultantsDxos
    {
        private readonly IMapper _mapper;

        public ConsultantsDxos()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Consultant, ConsultantDto>();
            });
            _mapper = config.CreateMapper();
        }


        public ConsultantDto MapConsultantDto(Consultant consultant) {
            return _mapper.Map<Consultant, ConsultantDto>(consultant);
        }

        public List<ConsultantDto> MapConsultantsDto(IEnumerable<Consultant> consultants)
        {
            return _mapper.Map<List<ConsultantDto>>(consultants);
        }
    }
}
