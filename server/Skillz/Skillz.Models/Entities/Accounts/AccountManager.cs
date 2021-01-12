using Skillz.Models.Companies;
using Skillz.Models.Entities.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Models.Entities.Accounts
{
    public class AccountManager:Person
    {
        public Guid? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public Guid? AccountId { get; set; }
        public virtual Account Account { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }



        private AccountManager()
        {

        }

        public AccountManager(Guid employeeId, Guid accountId)
        {
            EmployeeId = employeeId;
            AccountId = accountId;
        }

        
    }
}
