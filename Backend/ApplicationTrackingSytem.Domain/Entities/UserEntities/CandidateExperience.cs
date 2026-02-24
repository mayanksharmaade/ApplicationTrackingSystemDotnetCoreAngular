using ApplicationTrackingSytem.Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTrackingSytem.Domain.Entities.User
{
    public class CandidateExperience
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public string JobTitle { get; set; } = default!;
        public string CompanyName { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsCurrent { get; set; }
        public string? Description { get; set; }
        public Candidate Candidate { get; set; } = default!;
    }
}
