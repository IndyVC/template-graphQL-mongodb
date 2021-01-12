using Skillz.Contracts.Dto;
using Skillz.Models.Companies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Application.Dxos
{
    public interface ICompaniesDxos
    {
        CompanyDto MapCompanyDto(Company company);
        List<CompanyDto> MapCompaniesDto(IEnumerable<Company> organizations);
    }
}
