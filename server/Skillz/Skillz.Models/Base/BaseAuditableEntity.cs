using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Models
{
    public class BaseAuditableEntity : BaseEntity
    {
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
