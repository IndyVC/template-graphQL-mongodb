using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Contracts.Dto
{
    public class EvaluationQuestionDataDto
    {
        [JsonProperty("evaluation_categories")]
        public IEnumerable<IdTitleDto> Categories { get; set; }

        [JsonProperty("evaluation_groups")]
        public IEnumerable<IdTitleDto> Groups { get; set; }
    }
}
