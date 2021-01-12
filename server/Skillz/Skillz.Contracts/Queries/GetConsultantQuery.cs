using Newtonsoft.Json;
using Skillz.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Skillz.Contracts.Queries
{
    public class GetConsultantQuery : QueryBase<ConsultantDto>
    {
        [JsonProperty("id")]
        [Required]
        public Guid Id { get; set; }

        [JsonConstructor]
        public GetConsultantQuery(Guid id)
        {
            this.Id = id;
        }
    }
}
