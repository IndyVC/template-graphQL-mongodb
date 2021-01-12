using Newtonsoft.Json;
using Skillz.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Skillz.Contracts.Commands
{
    public class UpdateCompanyCommand : CommandBase<CompanyDto>
    {
        [JsonProperty("title")]
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }


        [JsonConstructor]
        public UpdateCompanyCommand(string title)
        {
            Title = title;
        }
    }
}
