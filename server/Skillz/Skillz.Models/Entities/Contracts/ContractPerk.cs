using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Models.Entities.Contracts
{
    public class ContractPerk:BaseAuditableEntity
    {
        public Guid ContractId { get; set; }
        public virtual Contract Contract { get; set; }

        public Guid PerkId { get; set; }
        public virtual Perk Perk { get; set; }

        public bool IsDeleted { get; set; }

        public string Info { get; set; }

        public Decimal Value { get; set; }

    }
}
