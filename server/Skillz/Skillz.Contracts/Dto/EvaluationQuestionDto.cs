using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Contracts.Dto
{
    public class EvaluationQuestionDto
    {

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("evaluationquestionetype_id")]
        public Guid EvaluationQuestionTypeId { get; set; }

        [JsonProperty("evaluationquestionecategory_id")]
        public Guid? EvaluationQuestionCategoryId { get; set; }
        public EvaluationQuestionCategoryDto EvaluationQuestionCategory { get; set; }

        [JsonProperty("evaluationquestiongroup_id")]
        public Guid? EvaluationGroupId { get; set; }
        public EvaluationQuestionGroupDto EvaluationQuestionGroup { get; set; }

        [JsonProperty("company_id")]
        public Guid? CompanyId { get; set; }
       
    }
}
