using Skillz.Models.Companies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Models.Entities.People
{
    public class Employee:Person
    {
        public string Email { get; set; }
        public string Phone { get; set; }

        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<EmployeeRole> Roles { get; set; }

        private Employee()
        {

        }

        public Employee(string firstName, string lastName, Guid companyId)
        {
            FirstName = firstName;
            LastName = lastName;
            CompanyId = companyId;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
