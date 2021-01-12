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
    public class QuestionsController : ApiControllerBase
    {
        public QuestionsController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProfileDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllQuestionsAsync()
        {
            return await ExecuteRequest(new GetAllEvaluationQuestionsQuery());
        }

        [HttpGet]
        [Route("data")]
        [ProducesResponseType(typeof(IEnumerable<EvaluationQuestionDataDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetQuestionsDataAsync()
        {
            return await ExecuteRequest(new GetEvaluationQuestionsDataQuery());
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
        public async Task<IActionResult> PostQuestionAsync([FromBody] AddEvaluationQuestionCommand command)
        {
            if (null == command) return BadRequest();
            return await ExecuteRequest(command);
        }

        //[HttpPut]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(404)]
        //public async Task<IAsyncResult> PutProfileAsync([FromBody] UpdateCompanyCommand command)
        //{
        //    return null;
        //}
    }
}