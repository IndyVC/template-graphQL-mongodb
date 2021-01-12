using Skillz.Models.Consultants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Models.Entities
{
    public class ConsultantNote:BaseAuditableEntity
    {
        public Guid ConsultantId { get; set; }
        public Consultant Consultant { get; set; }
        public string Text { get; set; }
        public bool IsDeleted { get; set; }

        private ConsultantNote()
        {

        }

        public ConsultantNote(string text)
        {
            Text = text;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
