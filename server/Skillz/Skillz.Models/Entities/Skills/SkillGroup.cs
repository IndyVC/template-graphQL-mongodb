using Skillz.Models.Companies;
using Skillz.Models.Entities.Profiles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Skillz.Models.Entities.Skills
{
    public class SkillGroup : BaseAuditableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("CompanyId")]
        public Guid? CompanyId { get; set; }
        public Company Company { get; set; }

        public virtual ICollection<SkillGroupSkill> Skills { get; set; }

        public Guid? ProfileId { get; set; }
        public Profile Profile { get; set; }


        private SkillGroup()
        {

        }


        public SkillGroup(string title, Guid companyId)
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
