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
   
    public class SkillsController : ApiControllerBase
    {
        public SkillsController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SkillDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllSkillssAsync()
        {
            return await ExecuteRequest(new GetAllSkillsQuery());
        }

        [HttpGet("/api/skills/groups")]
        [ProducesResponseType(typeof(SkillGroupDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetSkillGroupsAsync()
        {
            return await ExecuteRequest(new GetAllSkillGroupsQuery());
        }

        //[HttpGet("/api/skills/profiles")]
        //[ProducesResponseType(typeof(SkillGroupDto), 200)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(404)]
        //public async Task<IActionResult> GetSkillGroupsDataAsync()
        //{
        //    return await ExecuteRequest(new GetAllSkillsByProfileQuery());
        //}


        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostSkillAsync([FromBody] AddSkillCommand command)
        {
            if (null == command) return BadRequest();
            return await ExecuteRequest(command);
        }

        [HttpPost("/api/skills/groups")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostSkillGroupAsync([FromBody] AddSkillGroupCommand command)
        {
            if (null == command) return BadRequest();
            return await ExecuteRequest(command);
        }

        [HttpDelete]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteSkill(Guid id)
        {
            var companyid = new Guid("C0884A97-27BB-4DE7-96B2-C869ACFA8EA0");
            return await ExecuteRequest(new DeleteSkillCommand(id, companyid));
        }

        [HttpDelete("/api/skills/groups")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteSkillGroup(Guid id)
        {
            var companyid = new Guid("C0884A97-27BB-4DE7-96B2-C869ACFA8EA0");
            return await ExecuteRequest(new DeleteSkillGroupCommand(id, companyid));
        }
    }
}