using ApplicationTrackingSystem.Domain.Enums;
using ApplicationTrackingSytem.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTrackingSytem.Domain.Entities.UserEntities
{
    public class Application
    {
        public int Id { get; set; }
       // public int JobId { get; set; }
       
        public string? CoverLetterNote { get; set; }
        public ApplicationStatus Status { get; set; } = ApplicationStatus.Submitted;
        public DateTime AppliedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        //public Job Job { get; set; } = default!;
     
        public ICollection<ApplicationHistory> StatusHistory { get; set; } = new List<ApplicationHistory>();
        public Interview? Interview { get; set; }
    }
}
