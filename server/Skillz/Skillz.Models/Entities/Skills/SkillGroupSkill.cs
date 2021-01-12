using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Models.Entities.Skills
{
    public class SkillGroupSkill:BaseAuditableEntity
    {
        public Guid SkillId { get; set; }
        public Skill Skill { get; set; }

         public Guid SkillGroupId { get; set; }
        public SkillGroup SkillGroup { get; set; }
    }
}
