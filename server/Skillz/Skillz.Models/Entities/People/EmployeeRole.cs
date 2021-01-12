using Skillz.Models.Companies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Skillz.Models.Entities.People
{
    public class EmployeeRole : BaseEntity
    {
        public virtual Employee Employee { get; set; }
        public Guid EmployeeId { get; set; }

        public virtual Role Role { get; set; }
        public Guid RoleId { get; set; }

       
        private EmployeeRole()
        {
        }

        public EmployeeRole(Guid employeeId, Guid roleId)
        {

            EmployeeId = employeeId;
            RoleId =  roleId;
        }

       
    }
}
