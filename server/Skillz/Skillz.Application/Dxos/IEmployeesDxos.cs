using Skillz.Contracts.Dto;
using Skillz.Models.Consultants;
using Skillz.Models.Entities.Accounts;
using Skillz.Models.Entities.People;
using System.Collections.Generic;

namespace Skillz.Application.Dxos
{
    public interface IEmployeesDxos
    {
        EmployeeDto MapEmployeeDto(Employee employee);

        List<EmployeeDto> MapEmployeesDto(IEnumerable<Employee> employees);
    }
}
