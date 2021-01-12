using Newtonsoft.Json;
using Skillz.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Skillz.Contracts.Commands
{
    public class UpdateConsultantCommand : CommandBase<ConsultantDto>
    {
        [JsonProperty("firstname")]
        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }

        [JsonProperty("email")]
        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("mobile")]
        public string MobilePhone { get; set; }

        [JsonProperty("companyid")]
        [Required]
        public Guid CompanyId { get; set; }

        public UpdateConsultantCommand()
        {

        }

        [JsonConstructor]
        public UpdateConsultantCommand(string firstname, string lastname, string email, Guid companyId)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            CompanyId = companyId;
        }
    }
}
