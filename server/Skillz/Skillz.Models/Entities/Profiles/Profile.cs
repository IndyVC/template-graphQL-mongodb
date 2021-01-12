using Skillz.Models.Companies;
using Skillz.Models.Entities.Skills;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Skillz.Models.Entities.Profiles
{
    public class Profile : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<ConsultantProfile> Consultants { get; set; }
        public virtual ICollection<SkillGroup> SkillGroups { get; set; }

        [ForeignKey("CompanyId")]
        public Guid? CompanyId { get; set; }
        public Company Company { get; set; }

        private Profile()
        {
        }

        public Profile(string title, Guid companyId)
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
