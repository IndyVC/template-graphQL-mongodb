using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Models.Evaluations
{
    public class EvaluationQuestionType:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        private EvaluationQuestionType()
        {

        }

        public EvaluationQuestionType(string title)
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
