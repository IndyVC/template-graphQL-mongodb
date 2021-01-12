using Skillz.Models.Entities.Profiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Models.Companies
{
    public class Company: BaseAuditableEntity
    {
        public string Title { get; set; }

        public bool IsDeleted { get; set; }

        public IList<Profile> Profiles { get; set; }

        private Company()
        {

        }

        public Company(string title)
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
