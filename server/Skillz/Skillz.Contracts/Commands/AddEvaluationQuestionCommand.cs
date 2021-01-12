using Newtonsoft.Json;
using Skillz.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Skillz.Contracts.Commands
{
    public class AddEvaluationQuestionCommand : CommandBase<EvaluationQuestionDto>
    {
        [JsonProperty("title")]
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [JsonProperty("description")]
        [MaxLength(255)]
        public string Description { get; set; }

        [JsonProperty("company_id")]
        [Required]
        public Guid CompanyId { get; set; }

        [JsonProperty("evaluationquestiontype_id")]
        [Required]
        public Guid EvaluationQuestionTypeId { get; set; }

        [JsonProperty("evaluationquestioncategory_id")]
        public Guid? EvaluationQuestionCategoryId { get; set; }

        [JsonProperty("evaluationquestiongroup_id")]
        public Guid? EvaluationQuestionGroupId { get; set; }


        public AddEvaluationQuestionCommand()
        {

        }

        [JsonConstructor]
        public AddEvaluationQuestionCommand(string title, Guid evaluationQuestionTypeId, Guid companyId, Guid evaluationQuestionCategoryId, Guid evaluationQuestionGroupId)
        {
            Title = title;
            EvaluationQuestionTypeId = evaluationQuestionTypeId;
            CompanyId = companyId;
            EvaluationQuestionCategoryId = evaluationQuestionCategoryId;
            EvaluationQuestionGroupId = evaluationQuestionGroupId;
        }
    }
}
