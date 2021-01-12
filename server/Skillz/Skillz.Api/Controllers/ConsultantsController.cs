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
   
    public class ConsultantsController : ApiControllerBase
    {
        public ConsultantsController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ConsultantDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllConsultantsAsync()
        {
            return await ExecuteRequest(new GetAllConsultantsQuery());
        }

        [HttpGet("/api/consultants/{id}")]
        [ProducesResponseType(typeof(ConsultantDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetConsultantAsync(Guid id)
        {
            return await ExecuteRequest(new GetConsultantQuery(id));
        }


        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostConsultantAsync([FromBody] AddConsultantCommand command)
        {
            if (null == command) return BadRequest();
            return await ExecuteRequest(command);
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IAsyncResult> PutConsultantAsync([FromBody] UpdateConsultantCommand command)
        {
            return null;
        }
    }
}