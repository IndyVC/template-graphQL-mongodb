using AutoMapper;
using Skillz.Contracts.Dto;
using Skillz.Models.Companies;
using Skillz.Models.Consultants;
using Skillz.Models.Entities.Accounts;
using Skillz.Models.Entities.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Application.Dxos
{
    public class EmployeesDxos : IEmployeesDxos
    {
        private readonly IMapper _mapper;

        public EmployeesDxos()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDto>();
            });
            _mapper = config.CreateMapper();
        }


        public EmployeeDto MapEmployeeDto(Employee employee)
        {
            return _mapper.Map<Employee, EmployeeDto>(employee);
        }

        public List<EmployeeDto> MapEmployeesDto(IEnumerable<Employee> employees)
        {
            return _mapper.Map<List<EmployeeDto>>(employees);
        }
    }
}


