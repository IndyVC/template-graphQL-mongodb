using Newtonsoft.Json;
using Skillz.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Skillz.Contracts.Commands
{
    public class AddAccountCommand : CommandBase<AccountDto>
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        public Guid CompanyId { get; set; }
        public CompanyDto Company { get; set; }

        public AddAccountCommand()
        {

        }

        [JsonConstructor]
        public AddAccountCommand(string title, Guid companyId)
        {
            Title = title;
            CompanyId = companyId;
        }
    }
}
