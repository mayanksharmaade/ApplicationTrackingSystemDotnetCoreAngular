using ApplicationTrackingSytem.Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTrackingSytem.Domain.Entities.User
{
    public class CandidateEducation
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public string Institution { get; set; } = default!;
        public string Degree { get; set; } = default!;
        public string? FieldOfStudy { get; set; }
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }
        public string? Grade { get; set; }
        public Candidate Candidate { get; set; } = default!;
    }
}
