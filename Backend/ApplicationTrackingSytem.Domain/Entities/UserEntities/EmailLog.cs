using ApplicationTrackingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTrackingSytem.Domain.Entities.UserEntities
{
    public class EmailLog
    {

        public int Id { get; set; }
        public string ToEmail { get; set; } = default!;
        public string Subject { get; set; } = default!;
        public string Body { get; set; } = default!;
        public EmailStatus Status { get; set; } = EmailStatus.Pending;
        public DateTime? SentAt { get; set; }
        public string? ErrorMsg { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
