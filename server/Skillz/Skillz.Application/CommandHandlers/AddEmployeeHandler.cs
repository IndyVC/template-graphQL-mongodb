using MediatR;
using Microsoft.EntityFrameworkCore;
using Skillz.Application.Dxos;
using Skillz.Contracts.Commands;
using Skillz.Contracts.Dto;
using Skillz.Models.Consultants;
using Skillz.Models.Entities.People;
using Skillz.Models.Events;
using Skillz.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Skillz.Application.CommandHandlers
{
    public class AddEmployeeHandler : IRequestHandler<AddEmployeeCommand, EmployeeDto>
    {
        private readonly IRepository<Employee> _employeesRepository;
        private readonly IMediator _mediator;
        private readonly IEmployeesDxos _employeesDxo;

        public AddEmployeeHandler(IRepository<Employee> employeesRepository, IMediator mediator, IEmployeesDxos employeesDxo)
        {
            _employeesRepository = employeesRepository ?? throw new ArgumentNullException(nameof(IRepository<Employee>)); ;
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _employeesDxo = employeesDxo ?? throw new ArgumentNullException(nameof(employeesDxo));
        }

        public async Task<EmployeeDto> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee(
                request.FirstName,
                request.LastName,
                request.CompanyId);

            employee.Phone = request.Phone;

            _employeesRepository.Add(employee);

            if (await _employeesRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException();
            }

            //await _mediator.Publish(new ConsultantCreatedEvent(employee.Id), cancellationToken);

            var nw = await _employeesRepository.Query(e => e.Id == employee.Id).SingleAsync();
            var dto = _employeesDxo.MapEmployeeDto(nw);

            return dto;
        }
    }
}
