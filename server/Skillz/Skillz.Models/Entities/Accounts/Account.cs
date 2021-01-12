using Skillz.Models.Companies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Models.Entities.Accounts
{
    public class Account:BaseAuditableEntity
    {
        public string Title { get; set; }

        public bool IsDeleted { get; set; }

        public virtual IList<AccountManager> AccountManagers { get; set; }


        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }

        private Account()
        {

        }

        public Account(string title, Guid companyId)
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
