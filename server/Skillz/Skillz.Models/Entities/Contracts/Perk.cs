using Skillz.Models.Companies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Models.Entities.Contracts
{
    public class Perk : BaseAuditableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public Decimal NetValue { get; set; }
        public Decimal Tax { get; set; }
        public Decimal CompanyCost { get; set; }

        public virtual ICollection<ContractPerk> Contracts { get; set; }

        private Perk()
        {

        }

        public Perk(string title, Decimal netValue, Decimal tax, Guid companyId)
        {
            Title = title;
            NetValue = netValue;
            Tax = tax;
            CompanyId = companyId;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
