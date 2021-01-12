using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Models.Evaluations
{
    public class EvaluationResponse: BaseAuditableEntity
    {
        public Guid EvaluationQuestionId { get; set; }
        public EvaluationQuestion Question { get; set; }
        public string Value { get; set; }
    }
}
