using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Contracts.Dto
{
    public class AccountManagerDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public EmployeeDto Employee { get; set; }
        public AccountDto Account { get; set; }
    }
}
