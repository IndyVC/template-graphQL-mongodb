using Newtonsoft.Json;
using Skillz.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Contracts.Queries
{
    public class GetAllSkillsByProfileQuery : QueryBase<IEnumerable<SkillDto>>
    {
        public Guid ProfileId { get; set; }

        [JsonConstructor]
        public GetAllSkillsByProfileQuery(Guid profileId)
        {
            ProfileId = profileId;
        }
    }
}
