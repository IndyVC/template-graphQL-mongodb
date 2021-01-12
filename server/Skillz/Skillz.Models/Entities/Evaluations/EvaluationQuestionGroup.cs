using Skillz.Models.Companies;
using Skillz.Models.Evaluations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Skillz.Models.Entities.Evaluations
{
    public class EvaluationQuestionGroup : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        [ForeignKey("CompanyId")]
        public Guid? CompanyId { get; set; }
        public Company Company { get; set; }

        public Guid? EvaluationQuestionParentGroupId { get; set; }
        public EvaluationQuestionGroup EvaluationQuestionParentGroup { get; set; }

        public virtual ICollection<EvaluationQuestion> Questions { get; set; }

        public bool IsDeleted { get; set; }

        private EvaluationQuestionGroup()
        {

        }

        public EvaluationQuestionGroup(string title, Guid companyId)
        {
            Title = title;
            CompanyId = companyId;
        }

        public void Delete()
        {
            IsDeleted = true;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
