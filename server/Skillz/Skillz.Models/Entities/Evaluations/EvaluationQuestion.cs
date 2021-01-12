using Skillz.Models.Companies;
using Skillz.Models.Entities.Evaluations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Skillz.Models.Evaluations
{
    public class EvaluationQuestion:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Guid EvaluationQuestionTypeId { get; set; }
        public EvaluationQuestionType Type { get; set; }

        public Guid? EvaluationQuestionCategoryId { get; set; }
        public virtual EvaluationQuestionCategory EvaluationQuestionCategory { get; set; }

        [ForeignKey("CompanyId")]
        public Guid? CompanyId { get; set; }
        public Company Company { get; set; }


        [ForeignKey("EvaluationQuestionGroupId")]
        public Guid? EvaluationQuestionGroupId { get; set; }
        public virtual EvaluationQuestionGroup EvaluationQuestionGroup { get; set; }

        public bool IsDeleted { get; set; }

        private EvaluationQuestion()
        {

        }

        public EvaluationQuestion(string title, Guid evaluationQuestionTypeId, Guid companyId, Guid categoryId, Guid groupId) {
            Title = title;
            EvaluationQuestionTypeId = evaluationQuestionTypeId;
            CompanyId = companyId;
            EvaluationQuestionCategoryId = categoryId;
            EvaluationQuestionGroupId = groupId;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}


// type is --> meerkeuze, tekst, ...