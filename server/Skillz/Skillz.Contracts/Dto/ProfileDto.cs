using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Contracts.Dto
{
    public class ProfileDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("company_id")]
        public Guid CompanyId { get; set; }
    }
}
