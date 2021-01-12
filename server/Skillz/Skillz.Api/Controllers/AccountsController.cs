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
   
    public class AccountsController : ApiControllerBase
    {
        public AccountsController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AccountDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllAccountsAsync()
        {
            return await ExecuteRequest(new GetAllAccountsQuery());
        }


        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostAccountAsync([FromBody] AddAccountCommand command)
        {
            if (null == command) return BadRequest();
            return await ExecuteRequest(command);
        }

       
    }
}