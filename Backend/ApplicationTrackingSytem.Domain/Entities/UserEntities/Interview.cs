using ApplicationTrackingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTrackingSytem.Domain.Entities.UserEntities
{
    public class Interview
    {
        public int Id { get; set; }
       // public int ApplicationId { get; set; }
        public DateTime ScheduledAt { get; set; }
        public string? Location { get; set; }
        public InterviewType InterviewType { get; set; } = InterviewType.Video;
        public string? MeetingLink { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
       // public Application Application { get; set; } = default!;
    }
}
