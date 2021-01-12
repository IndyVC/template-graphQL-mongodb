using Skillz.Models.Entities.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Models.Entities.Profiles
{
    public class SkillProfile : BaseAuditableEntity
    {
        public Skill Skill { get; set; }
        public Guid SkillId { get; set; }

        public Guid ProfileId { get; set; }
        public Profile Profile { get; set; }

        

    }
}
