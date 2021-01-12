using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Models.Events
{
    public class ConsultantCreatedEvent : INotification
    {
        public Guid ConsultantId { get; set; }

        public ConsultantCreatedEvent(Guid consultantId)
        {
            ConsultantId = consultantId;
        }
    }
}
