using Skillz.Models.Consultants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Models.Entities.Profiles
{
    public class ConsultantProfile:BaseAuditableEntity
    {
        public Consultant Consultant { get; set; }
        public Guid ConsultantId { get; set; }

        public Guid ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}
