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
    public class CompaniesController : ApiControllerBase
    {
        public CompaniesController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CompanyDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllCompaniesAsync()
        {
            return await ExecuteRequest(new GetAllCompaniesQuery());
        }

        //[HttpGet("id")]
        //[ProducesResponseType(typeof(CompanyDto), 200)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(404)]
        //public async Task<IActionResult> GetOrganizationAsync(Guid id)
        //{
        //    return await ExecuteRequest(new GetOrganizationQuery(id));
        //}


        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostOrganizationAsync([FromBody] AddCompanyCommand command)
        {
            if (null == command) return BadRequest();
            return await ExecuteRequest(command);
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IAsyncResult> PutOrganizationAsync([FromBody] UpdateCompanyCommand command)
        {
            return null;
        }
    }
}