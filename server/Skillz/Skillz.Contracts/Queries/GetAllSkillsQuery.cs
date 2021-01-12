﻿using Newtonsoft.Json;
using Skillz.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Contracts.Queries
{
    public class GetAllSkillsQuery : QueryBase<IEnumerable<SkillDto>>
    {
        [JsonConstructor]
        public GetAllSkillsQuery()
        {

        }
    }
}
