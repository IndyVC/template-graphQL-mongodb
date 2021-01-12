using Skillz.Models.Companies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Skillz.Models.Evaluations
{
    public class EvaluationQuestionCategory:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        [ForeignKey("CompanyId")]
        public Guid? CompanyId { get; set; }
        public Company Company { get; set; }

        public bool IsDeleted { get; set; }


        private EvaluationQuestionCategory()
        {
        }

        public EvaluationQuestionCategory(string title)
        {
            Title = title;
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
