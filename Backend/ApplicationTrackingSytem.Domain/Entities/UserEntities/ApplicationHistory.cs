using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTrackingSytem.Domain.Entities.UserEntities
{
    public class ApplicationHistory
    {
        public int Id { get; set; }
      //  public int ApplicationId { get; set; }
        public string? OldStatus { get; set; }
        public string NewStatus { get; set; } = default!;
        public int ChangedBy { get; set; }
        public string? Notes { get; set; }
        public DateTime ChangedAt { get; set; } = DateTime.UtcNow;
       // public Application Application { get; set; } = default!;
    }
}
