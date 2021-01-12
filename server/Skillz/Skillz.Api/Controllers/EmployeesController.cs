using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Skillz.Contracts.Commands;
using Skillz.Contracts.Dto;
using Skillz.Contracts.Queries;


namespace Skillz.Api.Controllers
{
   
    public class EmployeesController : ApiControllerBase
    {
        public EmployeesController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EmployeeDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            return await ExecuteRequest(new GetAllEmployeesQuery());
        }


        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostEmployeeAsync([FromBody] AddEmployeeCommand command)
        {
            if (null == command) return BadRequest();
            return await ExecuteRequest(command);
        }

       
    }
}