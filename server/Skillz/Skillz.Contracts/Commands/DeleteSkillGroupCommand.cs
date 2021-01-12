using Newtonsoft.Json;
using Skillz.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Skillz.Contracts.Commands
{
    public class DeleteSkillGroupCommand : CommandBase<SkillGroupDto>
    {
        [JsonProperty("id")]
        [Required]
        public Guid Id { get; set; }

        [JsonProperty("companyid")]
        [Required]
        public Guid CompanyId { get; set; }

        public DeleteSkillGroupCommand()
        {

        }

        [JsonConstructor]
        public DeleteSkillGroupCommand(Guid id, Guid companyId)
        {
            this.Id = id;
            this.CompanyId = companyId;
        }
    }
}
