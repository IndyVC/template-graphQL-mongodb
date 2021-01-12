using Skillz.Models.Consultants;
using Skillz.Models.Entities.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Models.Entities.Consultants
{
    public class ConsultantSkill:BaseAuditableEntity
    {
        public Guid SkillId { get; set; }
        public virtual Skill Skill { get; set; }

        public Guid ConsultantId { get; set; }
        public virtual Consultant Consultant { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsCurrent { get; set; }
        public int Value { get; set; }

        public string Info { get; set; }
    }
}
