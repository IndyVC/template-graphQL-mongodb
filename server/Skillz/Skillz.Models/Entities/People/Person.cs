using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Models.Entities.People
{
    public abstract class Person : BaseAuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {

            return $"{FirstName} {LastName}";

        }
    }
}