using Newtonsoft.Json;
using Skillz.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Skillz.Contracts.Commands
{
    public class AddSkillGroupCommand : CommandBase<SkillGroupDto>
    {
        [JsonProperty("title")]
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [JsonProperty("description")]
        [MaxLength(255)]
        public string Description { get; set; }

       [JsonProperty("companyid")]
        [Required]
        public Guid CompanyId { get; set; }

        public AddSkillGroupCommand()
        {

        }

        [JsonConstructor]
        public AddSkillGroupCommand(string title, Guid companyId)
        {
            Title = title;
            CompanyId = companyId;
        }
    }
}
