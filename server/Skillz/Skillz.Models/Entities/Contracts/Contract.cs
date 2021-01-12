using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Models.Entities.Contracts
{
    public class Contract:BaseAuditableEntity
    {
        public string Function { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Decimal Salary { get; set; }

        public virtual ICollection<ContractPerk> Perks { get; set; }

        private Contract()
        {

        }

        public Contract(string function, DateTime startDate, Decimal salary)
        {
            this.Function = function;
            this.StartDate = startDate;
            this.Salary = salary;
        }

    }
}
