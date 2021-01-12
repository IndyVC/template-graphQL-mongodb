using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Contracts.Dto
{
    public class EmployeeDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("mobile")]
        public string MobilePhone { get; set; }

        public Guid CompanyId { get; set; }
        public CompanyDto Company { get; set; }
    }
}
