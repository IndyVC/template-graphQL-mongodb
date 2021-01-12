using AutoMapper;
using Skillz.Contracts.Dto;
using Skillz.Models.Companies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Application.Dxos
{
    public class CompaniesDxos:ICompaniesDxos
    {
        private readonly IMapper _mapper;

        public CompaniesDxos()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Company, CompanyDto>();
            });
            _mapper = config.CreateMapper();
        }


        public List<CompanyDto> MapCompaniesDto(IEnumerable<Company> companies) {
            return _mapper.Map<List<CompanyDto>>(companies);
        }

        public CompanyDto MapCompanyDto(Company company) {
            return _mapper.Map<Company, CompanyDto>(company);
        }
    }
}
