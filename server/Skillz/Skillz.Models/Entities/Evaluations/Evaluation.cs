using Skillz.Models.Consultants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Models.Evaluations
{
    public class Evaluation: BaseAuditableEntity
    {
        public Guid ConsultantId { get; set; }
        public Consultant Consultants { get; set; }
        public IList<EvaluationResponse> Questions { get; set; }
        public string UrlIdentifier { get; set; }
       
        public DateTime StartedDate { get; set; }
        public DateTime CompletedDate { get; set; }

        public bool IsPublished { get; set; }
    }
}
