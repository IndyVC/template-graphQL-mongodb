using Newtonsoft.Json;
using Skillz.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Skillz.Contracts.Commands
{
    public class AddCompanyCommand : CommandBase<CompanyDto>
    {

        [JsonProperty("title")]
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        

        public AddCompanyCommand()
        {

        }

        [JsonConstructor]
        public AddCompanyCommand(string title)
        {
            Title = title;
        }
    }
}
