using Newtonsoft.Json;
using Skillz.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Skillz.Contracts.Commands
{
    public class AddConsultantCommand : CommandBase<ConsultantDto>
    {
        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        public string Phone { get; set; }

        public string MobilePhone { get; set; }

        [Required]
        public Guid CompanyId { get; set; }

        public AddConsultantCommand()
        {

        }

        [JsonConstructor]
        public AddConsultantCommand(string firstname, string lastname, string email, Guid companyId)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            CompanyId = companyId;
        }
    }
}
